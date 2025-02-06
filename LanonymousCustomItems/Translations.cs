// -----------------------------------------------------------------------
// <copyright file="Translations.cs" company="Lanonymous">
// Copyright (c) Lanonymous. All rights reserved.
// Licensed under the CC BY-SA 4.0 license.
// -----------------------------------------------------------------------

using System.ComponentModel;
using Exiled.API.Interfaces;

namespace LanonymousCustomItems;

public class Translations : ITranslation
{
    [Description("Cyanide pills death message")]
    public string CyanidePillDeathMessage { get; set; } = "You have died from cyanide pill";
        
    [Description("Hint show if when using the hacking device the door is already locked.")]
    public string Alreadylocked { get; set; } = "This door is already locked!";
}