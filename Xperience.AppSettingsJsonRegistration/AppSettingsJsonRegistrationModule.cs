using System.Reflection;
using CMS;
using CMS.Core;
using Microsoft.Extensions.Configuration;
using XperienceCommunity.AppSettingsJsonRegistration;

using CMSModule = CMS.DataEngine.Module;

[assembly: RegisterModule(typeof(AppSettingsJsonRegistrationModule))]

namespace XperienceCommunity.AppSettingsJsonRegistration
{
    public class AppSettingsJsonRegistrationModule : CMSModule
    {
        public AppSettingsJsonRegistrationModule() : base(nameof(AppSettingsJsonRegistrationModule))
        {
            
        }

        protected override void OnPreInit()
        {
            base.OnPreInit();

            Service.Use<IConfiguration>(() => new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.local.json", true, true)
                .AddUserSecrets(Assembly.GetEntryAssembly(), true, true)
                .Build());
        }
    }
}