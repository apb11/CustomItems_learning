// -----------------------------------------------------------------------
// <copyright file="LanonymousCustomItems.cs" company="Lanonymous">
// Copyright (c) Lanonymous. All rights reserved.
// Licensed under the CC BY-SA 4.0 license.
//
// Some parts of this file are based on work by Joker119.
// Original code licensed under CC BY-SA 3.0. See license deed.
// -----------------------------------------------------------------------


using System;
using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using Server = Exiled.Events.Handlers.Server;
using LanonymousCustomItems.Events;

namespace LanonymousCustomItems;

public class LanonymousCustomItems : Plugin<Config, Translations>
{
    private ServerHandler _serverHandler = null!;
    public override Version Version { get; } = new Version(1, 0, 0);
    public override Version RequiredExiledVersion { get; } = new Version(9, 5, 0);
    public override string Name => "LanonymousCustomItems";
    public override string Author => "Sexy Lanonymous";
    public override string Prefix => "L.C.I";

    public static LanonymousCustomItems Instance { get; private set; } = null!;

    public override void OnEnabled()
    {
        Instance = this;
        _serverHandler = new ServerHandler();
        Config.LoadItems();
            
        Log.Debug("Registering items..");
        CustomItem.RegisterItems(overrideClass: Config.ItemConfigs);
        Server.ReloadedConfigs += _serverHandler.OnReloadingConfigs;
        if (Instance.Config.EnableInfoLogs)
        {
            Log.Info("===========================================");
            Log.Info("LanonymousCustomItems v1.0.0-PRE has been enabled!");
            Log.Info("Created by Sexy Lanonymous.");
            Log.Info("Need help? Our Github: https://github.com/RLLanonymous/LanonymousCustomItems");
            Log.Info("If you found an issue, please report it to Github.");
            Log.Info("First time you installed this plugin? Check configs/translations!");
            Log.Info("===========================================");
        }
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        CustomItem.UnregisterItems();
        Server.ReloadedConfigs -= _serverHandler.OnReloadingConfigs;
        if (Instance.Config.EnableInfoLogs)
        {
            Log.Info("===========================================");
            Log.Info("LanonymousCustomItems v1.0.0-PRE has been disabled!");
            Log.Info("Created by Sexy Lanonymous.");
            Log.Info("===========================================");
        }
        Instance = null;
        base.OnDisabled();
    }
}