// -----------------------------------------------------------------------
// <copyright file="CyanidePills.cs" company="Lanonymous">
// Copyright (c) Lanonymous. All rights reserved.
// Licensed under the CC BY-SA 4.0 license.
// -----------------------------------------------------------------------


using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using Player = Exiled.Events.Handlers.Player;
using CommandSystem;


namespace LanonymousCustomItems.CustomItems;

public class amnesticextractor
{
    [CustomItem(ItemType.Painkillers)]
    public class amnesticextractor : CustomItem
    {
        public ItemType ItemType { get; set; } = ItemType.Medkit;
            
        public override uint Id { get; set; } = 100;
            
        public override string Name { get; set; } = "amnestic extractor";
            
        public override string Description { get; set; } = "extract amnestics from 939's a amnestic cloud";
            
        public override float Weight { get; set; } = 0.5f;
            
        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 0,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new()
                {
                    Chance = 0,
                    Location = SpawnLocationType.InsideHczArmory,
                },
            },
        };
                
        protected override void SubscribeEvents()
        {
            Player.UsingItem += OnUsingItem;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Player.UsingItem -= OnUsingItem;
            base.UnsubscribeEvents();
        }
            
        public static Event<UsedItemEventArgs> UsedItem { get; set; }
        {
            if (ev.Hazardhandler.Type != Exiled.API.Enums.HazardType.AmnesticCloud) return;
                return;
            string giveItemCommand = $"/ci give {101} {playerId}";
                
            Timing.CallDelayed(10f, () => 
            {
                ev.Player.Kill(LanonymousCustomItems.Instance.Translation.CyanidePillDeathMessage);
                Log.Debug($"{ev.Player.Nickname} has killed himself with Cyanide Pill");
            });
        }
    }
}
