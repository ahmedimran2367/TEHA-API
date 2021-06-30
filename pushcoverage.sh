#/bin/sh
dotnet tool install --global coverlet.console 
dotnet add TEHA.Portal.API.Test package coverlet.msbuild --version 2.8.0

# Running unit tests - 'cobertura' output format
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=coverage /p:Exclude=[xunit.*]* TEHA.Portal.sln

bash <(curl -Ls https://coverage.codacy.com/get.sh) report -l CSharp -t e92d0c9e6a7a4308992fd2901ea73bc3 -r TEHA.Portal.API.Test/coverage.cobertura.xml
# Send test report result to codacy
#java -jar ./Waste.ClientIdentity/codacy-test-reporter.jar report -l CSharp -t e92d0c9e6a7a4308992fd2901ea73bc3 -r Waste.ClientIdentity/Waste.ClientIdentity.API.Test/coverage.cobertura.xml