// -----------------------------------------------------------------------
// <copyright file="SniperRifle.cs" company="Lanonymous">
// Copyright (c) Lanonymous. All rights reserved.
// Licensed under the CC BY-SA 4.0 license.
//
// Some parts of this file are based on work by Joker119.
// Original code licensed under CC BY-SA 3.0. See license deed.
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Firearms.Attachments;
using PlayerStatsSystem;
using YamlDotNet.Serialization;

namespace LanonymousCustomItems.CustomItems;

public class SniperRifle
{
    [CustomItem(ItemType.GunE11SR)]
    public class SniperRifleItem : CustomWeapon
    {
        public ItemType ItemType { get; set; } = ItemType.GunE11SR;
            
        public override uint Id { get; set; } = 104;
            
        public override string Name { get; set; } = "FR-F2";
            
        public override string Description { get; set; } = "This FR-F2 is very good at killing is opponents!";
            
        public override float Weight { get; set; } = 3.25f;
            
        public override byte ClipSize { get; set; } = 10;
            
        public override bool ShouldMessageOnGban { get; } = true;
            
        [YamlIgnore]
        public override float Damage { get; set; }
            
        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new()
                {
                    Chance = 100,
                    Location = SpawnLocationType.InsideLczArmory,
                },
            },
        };
            
        [YamlIgnore]
        public override AttachmentName[] Attachments { get; set; } = new[]
        {
            AttachmentName.ExtendedBarrel,
            AttachmentName.ScopeSight,
        };
            
        [Description("The amount of extra damage this weapon does, as a multiplier.")]
        public float DamageMultiplier { get; set; } = 3.50f;
            
        protected override void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker != ev.Player && ev.DamageHandler.Base is FirearmDamageHandler firearmDamageHandler && firearmDamageHandler.WeaponType == ev.Attacker.CurrentItem.Type)
                ev.Amount *= DamageMultiplier;
        }
    }
}