    [CmdletBinding()]
    param (
        [ValidateSet("ConsoleApp", "WebApi")]
        [string] $project = "ConsoleApp",
        [ValidateSet("ConsoleApp", "WebApi", "MyEnvironment")]
        [string] $launchProfile = "Config$project"
    )

    Write-Host "dotnet run --project 'src/Config$project/Config$project.csproj' -c Debug --launch-profile $launchProfile --watch"
    dotnet run --project "src/Config$project/Config$project.csproj" -c Debug --launch-profile $launchProfile --watch