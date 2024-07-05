param(
    [string]$Command
)

$commands = @("test", "bm")

if ($Command -eq $commands[0]) {
    dotnet test
}
elseif ($Command -eq $commands[1]) {
    dotnet run --project .\Geode.Benchmarks\Geode.Benchmarks.csproj --configuration Release --filter * --join
}
else {
    Write-Host "Unknown command $Command. Please use: $($commands -join ', ')"
}