﻿/*
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

namespace immutabilis
{
    /// <summary>
    /// The public interface of the service that provides the main entry point for the application.
    /// </summary>
    internal interface IApplication
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The arguments passed to the application on the command line.</param>
        /// <returns>The result of running the application.</returns>
        Task<ResultCode> Main(string[] args);
    }
}