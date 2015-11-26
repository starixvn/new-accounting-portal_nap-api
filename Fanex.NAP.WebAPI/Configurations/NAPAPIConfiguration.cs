namespace Fanex.NAP.WebAPI.Configurations
{
    using System.Configuration;

    public class NAPAPIConfiguration : ConfigurationSection
    {
        private static NAPAPIConfiguration settings
            = ConfigurationManager.GetSection("NAPAPIConfiguration") as NAPAPIConfiguration;

        public static NAPAPIConfiguration Settings
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty("EnableLogging", IsRequired = false, DefaultValue = false)]
        public bool EnableLogging
        {
            get { return (bool)this["EnableLogging"]; }
            set { this["EnableLogging"] = value; }
        }
    }
}