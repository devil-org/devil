[CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$Name
    )

cd $PSScriptRoot\Devil.Web\Server

dotnet ef migrations add $Name --project ../../Migrations/Devil.Domain.MsSqlServerMigrations -- --DatabaseType mssql
dotnet ef migrations add $Name --project ../../Migrations/Devil.Domain.SqliteMigrations -- --DatabaseType sqlite
dotnet ef migrations add $Name --project ../../Migrations/Devil.Domain.MySqlMigrations -- --DatabaseType mysql
dotnet ef migrations add $Name --project ../../Migrations/Devil.Domain.PostgresMigrations -- --DatabaseType postgres

cd $PSScriptRoot