param(
    [string]$Command
)

$commands = @("test", "bm", "cc")

if ($Command -eq $commands[0]) {
    dotnet test
}
elseif ($Command -eq $commands[1]) {
    dotnet run --project .\Geode.Benchmarks\Geode.Benchmarks.csproj --configuration Release --filter * --join
}
elseif ($Command -eq $commands[2]) {
    dotnet test .\Geode.Tests\Geode.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura &&
    reportgenerator -reports:.\Geode.Tests\coverage.cobertura.xml -targetdir:.\Geode.Tests\ccreport &&
    Start-Process .\Geode.Tests\ccreport\index.html
}
else {
    Write-Host "Unknown command $Command. Please use: $($commands -join ', ')"
}