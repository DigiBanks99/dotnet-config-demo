[CmdletBinding()]
param (
    [ValidateSet("ConsoleApp", "WebApi")]
    [string] $project = "ConsoleApp"
)

Write-Host "dotnet run --project 'src/Config$project/Config$project.csproj' -c Debug --launch-profile 'Config$project' --watch"
dotnet run --project "src/Config$project/Config$project.csproj" -c Debug --launch-profile "Config$project" --watch