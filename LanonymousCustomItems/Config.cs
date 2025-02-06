using System.ComponentModel;
using Exiled.API.Interfaces;
using System.IO;
using Exiled.API.Features;
using Exiled.Loader;

namespace LanonymousCustomItems
{
    public class Config : IConfig
    {
        [Description("Should the plugin be load everytime Exiled load?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should the plugin be in Debug mode?")]
        public bool Debug { get; set; } = false;

        [Description("Should the plugin log basic information?")]
        public bool EnableInfoLogs { get; set; } = true;

        [Description("Cyanide pills death message")]
        public string CyanidePillDeathMessage { get; set; } = "You have died from cyanide pill";

        public Configs.Items ItemConfigs { get; private set; } = null!;

        public string ItemConfigFolder { get; set; } = Path.Combine(Paths.Configs, "LanonymousCustomItems");

        public string ItemConfigFile { get; set; } = "global.yml";

        public void LoadItems()
        {
            if (!Directory.Exists(ItemConfigFolder))
                Directory.CreateDirectory(ItemConfigFolder);

            string filePath = Path.Combine(ItemConfigFolder, ItemConfigFile);
            Log.Info($"{filePath}");
            if (!File.Exists(filePath))
            {
                ItemConfigs = new Configs.Items();
                File.WriteAllText(filePath, Loader.Serializer.Serialize(ItemConfigs));
            }
            else
            {
                ItemConfigs = Loader.Deserializer.Deserialize<Configs.Items>(File.ReadAllText(filePath));
                File.WriteAllText(filePath, Loader.Serializer.Serialize(ItemConfigs));
            }
        }
    }
}