#tool nuget:?package=ReportGenerator&version=4.8.1

/*
 * This file is part of immutabilis.
 *
 * Copyright © 2022 Xavier Evans (xavierevans341@gmail.com) and Jonathan Evans (jevans@open-collar.org.uk). All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */

/* ***************************************************************************
 * Arguments
 * ***************************************************************************/

var target = Argument<string>("target", "Build");
var configuration = Argument<string>("configuration", "Release");
var isDesktop = Argument<bool>("isDesktop", false);
var customBuild = Argument<string>("customBuild", isDesktop ? "desktop" : string.Empty);
var buildNumber = Argument<int>("buildNumber", 9999);

string major;
string minor;
string revision;
string version;

/* ***************************************************************************
 * Environment
 * ***************************************************************************/

var parentDirectory = Directory(".");
var coverageDirectory = parentDirectory + Directory("../docs/coverage");
var coberturaFileName = "results";
var coberturaFileExtension = ".cobertura.xml";
var reportTypes = "Html";
var coverageFilePath = new GlobPattern(((string)coverageDirectory) + "/**/*" + coberturaFileExtension);

/* ***************************************************************************
 * Tasks
 * ***************************************************************************/

Task("WriteVersion")
    .Does(() =>
    {
        major = System.IO.File.ReadAllText(System.IO.Path.Combine(".version", "major.txt"));
        minor = System.IO.File.ReadAllText(System.IO.Path.Combine(".version", "minor.txt"));
        revision = buildNumber.ToString("D");
        System.IO.File.WriteAllText(System.IO.Path.Combine(".version", "revision.txt"), revision);

        version = $"{major}.{minor}.{revision}";

        if (!string.IsNullOrWhiteSpace(customBuild))
        {
            version = $"{version}-{customBuild}";
        }

        System.IO.File.WriteAllText(System.IO.Path.Combine(".version", "version.txt"), version);

        Information($"Major: {major}");
        Information($"Minor: {minor}");
        Information($"Revision: {revision}");
        Information($"Custom Build: \"{ customBuild}\"");
        Information($"Version: {version}");
    });

Task("Clean")
    .Does(() =>
    {
        Information("Cleaning documentation.");
        CleanDirectory($"../docs");
    });

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var buildSettings = new DotNetBuildSettings
    {
        Framework = "net6.0",
        Configuration = configuration,
        ArgumentCustomization = args => args.Append($"-P:Version={version}").Append("--no-dependencies")
    };

    Information($"Building: ../src/immutabilis/immutabilis.csproj");
    DotNetBuild("../src/immutabilis/immutabilis.csproj", buildSettings);
});

Task("Publish")
    .IsDependentOn("Build")
    .Does(() =>
{
    var buildSettings = new DotNetPublishSettings
    {
        Framework = "net6.0",
        Configuration = configuration,
        ArgumentCustomization = args => args.Append($"-P:Version={version}").Append("--no-dependencies"),
         OutputDirectory = "../artifacts/console/"
    };

    Information($"Publishing: ../src/immutabilis/immutabilis.csproj");
    DotNetPublish("../src/immutabilis/immutabilis.csproj", buildSettings);
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    CreateDirectory("../../docs/Coverage");

    var testSettings = new DotNetCoreTestSettings
    {
        Framework = "net6.0",
        Configuration = configuration,
        ArgumentCustomization = args => args.Append("--collect:\"XPlat Code Coverage \"").Append($"-r \"{coverageDirectory}\"").Append("--no-build")
    };

    var buildSettings = new DotNetBuildSettings
    {
        Framework = "net6.0",
        Configuration = configuration,
        ArgumentCustomization = args => args.Append($"-P:Version={version}").Append("--no-dependencies")
    };

    Information($"Building: ../test/immutabilis.TEST/immutabilis.TEST.csproj");
    DotNetBuild("../test/immutabilis.TEST/immutabilis.TEST.csproj", buildSettings);

    Information($"Executing tests: ../test/immutabilis.TEST/immutabilis.TEST.csproj");
    DotNetCoreTest("../test/immutabilis.TEST/immutabilis.TEST.csproj", testSettings);

    // Move coverage files up a level
    var directories = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
    foreach (var file in System.IO.Directory.EnumerateFiles("../../docs/Coverage", "*.cobertura.xml", System.IO.SearchOption.AllDirectories))
    {
        var dirPath = System.IO.Path.GetDirectoryName(file);
        if (!directories.ContainsKey(dirPath))
        {
            directories.Add(dirPath, dirPath);
        }
        var fileName = System.IO.Path.GetFileName(file);
        var newFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(dirPath), fileName);
        System.IO.File.Move(file, newFile);
    }

    // Delete the custom directories
    foreach (var dirPath in directories.Values)
    {
        System.IO.Directory.Delete(dirPath, true);
    }

    var settings = new ReportGeneratorSettings();
    ReportGenerator(coverageFilePath, coverageDirectory, settings);
});

Task("Release")
    .IsDependentOn("Clean")
    .IsDependentOn("WriteVersion")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Publish")
    .Does(() =>
{
});

/* ***************************************************************************
 * Execute
 * ***************************************************************************/

RunTarget(target);