[CmdletBinding()]
param(
    [string]$Context = "ApplicationDbContext",
    [string]$Configuration = "Debug"
)

$ErrorActionPreference = "Stop"
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot "..")
Push-Location $repoRoot
try {
    dotnet tool restore
    dotnet ef database update `
        --context $Context `
        --project "Healthcare.Infrastructure/Healthcare.Infrastructure.csproj" `
        --startup-project "Healthcare.Web/Healthcare.Web.csproj" `
        --configuration $Configuration
}
finally {
    Pop-Location
}
