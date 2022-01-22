# immutabilis
.NET assembly version compatibility validation.

## Purpose

This tool is intended for use in build/deployment processes to validate that a candidate
assembly has not broken compatibility with a baseline version.  It can also detect,
classify and report upon any breaking changes or risks that are discovered.

And extensibility model allows for customisation of the detection, classification
and reporting processes to meet individual needs.

# Usage

`immutabilis [flags] <baseline-assembly-path> <candidate-assembly-path> <results-file-path>`

# Developers

## Source Code
[GitHub Repository](https://github.com/open-collar/immutabilis) (pull requests by invitation only)

## Build
[![Build](https://github.com/open-collar/immutabilis/actions/workflows/build.yml/badge.svg)](https://github.com/open-collar/immutabilis/actions/workflows/build.yml)

## Issues
[Issues](https://github.com/open-collar/immutabilis/issues) (by invitation only)

## Slack

[#immutablilis](https://open-collar.slack.com/archives/C030ARN3G8Y) (by invitation only)

## Tools

Below are the tools that are required or recommend for developing immutablilis.

### Required Tools

These tools are require to build the immutablilis tools.

* [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) (this SDK will also be installed as part of a Visual Studio installation);

### Recommended Tools

These tools are not strictly required, but have been proven to work as a development
environment.

* [Visual Studio 2022 (Community)](https://visualstudio.microsoft.com/downloads/)
* Extensions:
   * Cake for Visual Studio 2022;
   * [Ghostdoc Community for Visual Studio 2017 and Later](https://submain.com/download/ghostdoc/community/)
   * Markdown Editor (64-bit);

# Background Reading

* [Semantic Versioning 2.0.0](https://semver.org/)
* Command Line Parser (used to parse command lines and generate documentation etc.):
  * [GitHub](https://github.com/commandlineparser/commandline)
  * [Nuget](https://www.nuget.org/packages/CommandLineParser/)