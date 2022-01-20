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

using Microsoft.Extensions.DependencyInjection;

namespace immutabilis;

/// <summary>
/// The primary applciation class.
/// </summary>
public static class Program
{
    /// <summary>
    /// The main application entry point.
    /// </summary>
    /// <param name="args">The arguments passed to the application on the command line.</param>
    /// <returns>The result code from running the application.</returns>
    public static async Task<int> Main(string[] args)
    {
        // We use services here to implement dependency injection.  This makes unit testing
        // simpler, and  later, when we add features such as extensibility, it will help.
        var services = new ServiceCollection();
        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        services.AddSingleton<IApplication, Application>();
        var provider = services.BuildServiceProvider();

        var application = provider.GetRequiredService<IApplication>();

        return (int)await application.Main(args);
    }
}