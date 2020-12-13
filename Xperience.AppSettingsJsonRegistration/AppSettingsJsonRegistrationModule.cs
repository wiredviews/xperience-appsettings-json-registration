using CMS;
using CMS.Core;
using CMS.DataEngine;
using Microsoft.Extensions.Configuration;
using XperienceCommunity.AppSettingsJsonRegistration;

[assembly: RegisterModule(typeof(AppSettingsJsonRegistrationModule))]

namespace XperienceCommunity.AppSettingsJsonRegistration
{
    public class AppSettingsJsonRegistrationModule : Module
    {
        public AppSettingsJsonRegistrationModule() : base(nameof(AppSettingsJsonRegistrationModule))
        {
            
        }

        protected override void OnPreInit()
        {
            base.OnPreInit();

            Service.Use<IConfiguration>(() => new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build());
        }
    }
}