using System.ComponentModel;
using Exiled.API.Interfaces;

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
        
        [Description("Should the plugin log basic information?")]
        public string CyanidePillDeathMessage { get; set; } = "Cyanide pill has killed you!";
    }
}