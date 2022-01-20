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

using System.Threading.Tasks;

using Xunit;

namespace immutabilis.TEST
{
    public class ApplicationTests
    {
        [Fact]
        public async Task TextMainAsync()
        {
            var console = new ConsoleWriterMock();

            var application = new Application(console);

            var result = await application.Main(new string[0]);

            Assert.Equal(ResultCode.NoArgs, result);
            Assert.Equal(2, console.Output.Count);

        }
    }
}