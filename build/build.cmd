@ECHO OFF

REM This file is part of immutabilis.
REM
REM Copyright © 2022 Xavier Evans (xavierevans341@gmail.com) and Jonathan Evans (jevans@open-collar.org.uk). All Rights Reserved.
REM
REM Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
REM the License. You may obtain a copy of the License at
REM
REM http://www.apache.org/licenses/LICENSE-2.0
REM
REM Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
REM an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
REM specific language governing permissions and limitations under the License.
REM

CALL dotnet cake --target="Release" --configuration="Release" --isDesktop=true --buildNumber=8888