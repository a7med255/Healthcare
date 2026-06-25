#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
REPO_ROOT="$(cd "$SCRIPT_DIR/.." && pwd)"
CONTEXT="${1:-ApplicationDbContext}"
CONFIGURATION="${2:-Debug}"

cd "$REPO_ROOT"
dotnet tool restore
dotnet ef database update \
  --context "$CONTEXT" \
  --project "Healthcare.Infrastructure/Healthcare.Infrastructure.csproj" \
  --startup-project "Healthcare.Web/Healthcare.Web.csproj" \
  --configuration "$CONFIGURATION"
