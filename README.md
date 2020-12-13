# Xperience appsettings.json Registration

[![NuGet Package](https://img.shields.io/nuget/v/WiredViews.Xperience.AppSettingsJsonRegistration.svg)](https://www.nuget.org/packages/WiredViews.Xperience.AppSettingsJsonRegistration)

This package provides a [Kentico Xperience 13.0](https://docs.xperience.io/developing-websites/developing-xperience-applications-using-asp-net-core/) custom module to auto-register the ASPNET Core appsettings.json as Xperience's configuration source.

This is useful in [Console applications](https://docs.xperience.io/developing-websites/developing-xperience-applications-using-asp-net-core/starting-with-asp-net-core-development#StartingwithASP.NETCoredevelopment-Workingwithapplicationsettings) which do not use an IHostBuilder to configure the application.

## Dependencies

This package is compatible with ASP.NET Core 3.1 -> ASP.NET Core 5 and is designed to be used with .NET Core / .NET 5 Console applications integrated with Kentico Xperience 13.0.

## How to Use?

1. First, install the NuGet package in your ASP.NET Core project

   ```bash
   dotnet add package WiredViews.Xperience.AppSettingsJsonRegistration
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

## References

### Kentico Xperience

- [Working with application settings](https://docs.xperience.io/developing-websites/developing-xperience-applications-using-asp-net-core/starting-with-asp-net-core-development#StartingwithASP.NETCoredevelopment-Workingwithapplicationsettings)
- [Using the MSBuild `<AssemblyAttribute>`](https://devnet.kentico.com/questions/kentico-13-why-i-can-t-get-the-current-page-type-only-the-treenode)
- [Using the Xperience API externally](https://docs.xperience.io/integrating-3rd-party-systems/using-the-xperience-api-externally)
