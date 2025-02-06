using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomItems;
using Exiled.CustomItems.API.Features;
using LanonymousCustomItems.CustomItems;
using Server = Exiled.Events.Handlers.Server;
using HarmonyLib;
using LanonymousCustomItems.Events;

namespace LanonymousCustomItems
{
    
    public class LanonymousCustomItems : Plugin<Config>
    {
        private ServerHandler serverHandler = null!;
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(9, 5, 0);
        public override string Name { get; } = "LanonymousCustomItems";
        public override string Author { get; } = "Sexy Lanonymous";
        public override string Prefix { get; } = "L.C.I";

        public static LanonymousCustomItems Instance { get; private set; } = null!;

        public override void OnEnabled()
        {
            Instance = this;
            serverHandler = new ServerHandler();
            Config.LoadItems();
            
            Log.Debug("Registering items..");
            CustomItem.RegisterItems(overrideClass: Config.ItemConfigs);
            Server.ReloadedConfigs += serverHandler.OnReloadingConfigs;
            if (Instance.Config.EnableInfoLogs)
            {
                Log.Info("===========================================");
                Log.Info("LanonymousCustomItems v1.0.0 has been enabled!");
                Log.Info("Created by Sexy Lanonymous");
                Log.Info("===========================================");
            }
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            CustomItem.UnregisterItems();
            Server.ReloadedConfigs -= serverHandler.OnReloadingConfigs;
            if (Instance.Config.EnableInfoLogs)
            {
                Log.Info("===========================================");
                Log.Info("LanonymousCustomItems v1.0.0 has been disabled!");
                Log.Info("Created by Sexy Lanonymous");
                Log.Info("===========================================");
            }
            Instance = null;
            base.OnDisabled();
        }
    }
}