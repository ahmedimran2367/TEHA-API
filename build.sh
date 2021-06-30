#/bin/sh
export PROJECT_NAME=TEHA.Portal/TEHA.Portal.API
export Solution=TEHA.Portal
git submodule update --init --remote
dotnet restore $PROJECT_NAME
dotnet build $PROJECT_NAME