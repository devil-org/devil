[CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$Name
    )


cd $PSScriptRoot\Devil.Web\Server

dotnet ef migrations add $Name --project ../../Devil.Domain.MsSqlServerMigrations -- --provider mssql
dotnet ef migrations add $Name --project ../../Devil.Domain.SqliteMigrations -- --provider sqlite
dotnet ef migrations add $Name --project ../../Devil.Domain.MySqlMigrations -- --provider mysql
dotnet ef migrations add $Name --project ../../Devil.Domain.MsSqlServerMigrations -- --provider postgres