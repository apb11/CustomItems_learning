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


namespace LanonymousCustomItems.CustomItems;

public class CyanidePill
{
    [CustomItem(ItemType.Painkillers)]
    public class CyanidePillItem : CustomItem
    {
        public ItemType ItemType { get; set; } = ItemType.Painkillers;
            
        public override uint Id { get; set; } = 100;
            
        public override string Name { get; set; } = "Cyanide pill";
            
        public override string Description { get; set; } = "A cyanide pill.";
            
        public override float Weight { get; set; } = 0.5f;
            
        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new()
                {
                    Chance = 100,
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
            
        private void OnUsingItem(UsingItemEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;
            ev.Player.EnableEffect(EffectType.Blurred,10, 10f, true);
                
            Timing.CallDelayed(10f, () => 
            {
                ev.Player.Kill(LanonymousCustomItems.Instance.Translation.CyanidePillDeathMessage);
                Log.Debug($"{ev.Player.Nickname} has killed himself with Cyanide Pill");
            });
        }
    }
}