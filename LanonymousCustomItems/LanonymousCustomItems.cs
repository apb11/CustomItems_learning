using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomItems.API.Features;

namespace LanonymousCustomItems
{
    public class LanonymousCustomItems : Plugin<Config>
    {
        public static LanonymousCustomItems Instance { get; private set; }
        
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override Version Version { get; } = new Version(1,0,0);
        public override Version RequiredExiledVersion { get; } = new Version(9, 5, 0);
        public override string Name { get; } = "LanonymousCustomItems";
        public override string Author { get; } = "Sexy Lanonymous";
        public override string Prefix { get; } = "L.C.I";
        
        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            CustomItem.RegisterItems();
            
            if (Instance.Config.EnableInfoLogs)
            {
                Log.Info("===========================================");
                Log.Info("LanonymousCustomItems v1.0.0 has been enabled!");
                Log.Info("Created by Sexy Lanonymous");
                Log.Info("===========================================");
            }
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            CustomItem.UnregisterItems();
            
            if (Instance.Config.EnableInfoLogs)
            {
                Log.Info("===========================================");
                Log.Info("LanonymousCustomItems v1.0.0 has been disabled!");
                Log.Info("Created by Sexy Lanonymous");
                Log.Info("===========================================");
            }
        }
    }
}