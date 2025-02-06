// -----------------------------------------------------------------------
// <copyright file="ServerHandler.cs" company="Lanonymous">
// Copyright (c) Lanonymous. All rights reserved.
// Licensed under the CC BY-SA 4.0 license.
//
// Some parts of this file are based on work by Joker119.
// Original code licensed under CC BY-SA 3.0. See license deed.
// -----------------------------------------------------------------------

namespace LanonymousCustomItems.Events;

public class ServerHandler
{
    public void OnReloadingConfigs()
    {
        LanonymousCustomItems.Instance.Config.LoadItems();
    }
}