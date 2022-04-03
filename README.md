# Xperience appsettings.json Registration

[![NuGet Package](https://img.shields.io/nuget/v/XperienceCommunity.AppSettingsJsonRegistration.svg)](https://www.nuget.org/packages/XperienceCommunity.AppSettingsJsonRegistration)

This package provides a [Kentico Xperience 13.0](https://docs.xperience.io/developing-websites/developing-xperience-applications-using-asp-net-core/) custom module to auto-register the ASPNET Core appsettings.json as Xperience's configuration source.

This is useful in [Console applications](https://docs.xperience.io/developing-websites/developing-xperience-applications-using-asp-net-core/starting-with-asp-net-core-development#StartingwithASP.NETCoredevelopment-Workingwithapplicationsettings) which do not use an IHostBuilder to configure the application.

## Dependencies

This package is compatible with ASP.NET Core 3.1 -> ASP.NET Core 5 and is designed to be used with .NET Core / .NET 5 Console applications integrated with Kentico Xperience 13.0.

## How to Use?

1. First, install the NuGet package in your ASP.NET Core project

   ```bash
   dotnet add package XperienceCommunity.AppSettingsJsonRegistration
   ```

1. Create an `appsettings.json` file at the root of your console app project with the `CMSConnectionString`

   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
       }
     },
     "ConnectionStrings": {
       "CMSConnectionString": "<your connection string here>"
     }
   }
   ```

1. Ensure the `appsettings.json` file is configured to copy to the output directory on build by editing your console application's `.csproj` file and adding the following (if it doesn't already exist)

   ```xml
   <ItemGroup>
        <None Update="appsettings.json">
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
   </ItemGroup>
   ```

1. Add the call to `CMSApplication.Init();` at the beginning of your `Main()` method

   ```csharp
   class Program
   {
       static void Main(string[] args)
       {
           CMSApplication.Init();

           // ...
       }
   }
   ```

This package also supports having a `appsettings.local.json` which is optional and can be ignored in your source control.

It can also support [User Secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows). First add the package to your application:

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="3.1.11" />
</ItemGroup>
```

Then right click on your project in Visual Studio and select "Manage User Secrets" to create the secrets file.

Secrets can also be managed for a project, outside of Visual Studio, [at the commend line](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows#enable-secret-storage) using the .NET CLI.

## Contributions

If you discover a problem, please [open an issue](https://github.com/wiredviews/xperience-appsettings-json-registration/issues/new).

If you would like contribute to the code or documentation, please [open a pull request](https://github.com/wiredviews/xperience-appsettings-json-registration/compare).

## References

### Kentico Xperience

- [Working with application settings](https://docs.xperience.io/developing-websites/developing-xperience-applications-using-asp-net-core/starting-with-asp-net-core-development#StartingwithASP.NETCoredevelopment-Workingwithapplicationsettings)
- [Using the MSBuild `<AssemblyAttribute>`](https://devnet.kentico.com/questions/kentico-13-why-i-can-t-get-the-current-page-type-only-the-treenode)
- [Using the Xperience API externally](https://docs.xperience.io/integrating-3rd-party-systems/using-the-xperience-api-externally)
