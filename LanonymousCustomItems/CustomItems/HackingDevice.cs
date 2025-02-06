// -----------------------------------------------------------------------
// <copyright file="HackingDevice.cs" company="Lanonymous">
// Copyright (c) Lanonymous. All rights reserved.
// Licensed under the CC BY-SA 4.0 license.
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using Player = Exiled.Events.Handlers.Player;

namespace LanonymousCustomItems.CustomItems;

public class HackingDevice
{
    [CustomItem(ItemType.KeycardChaosInsurgency)]
    public class HackingDeviceItem : CustomItem
    {
        public ItemType ItemType { get; set; } = ItemType.KeycardChaosInsurgency;
            
        public override uint Id { get; set; } = 105;
            
        public override string Name { get; set; } = "Hacking Device";
            
        public override string Description { get; set; } = "A hacking device that can temporarily lock down doors.";
            
        public override float Weight { get; set; } = 0.5f;
            
        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new()
                {
                    Chance = 100,
                    Location = SpawnLocationType.Inside079Secondary,
                },
            },
        };

        private readonly Dictionary<Door, bool> _lockedDoors = new();
            
        [Description("The duration of the lockdown.")]
        public const float LockdownDuration = 15f; 
            
                
        protected override void SubscribeEvents()
        {
            Player.InteractingDoor += OnInteractingDoor;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Player.InteractingDoor -= OnInteractingDoor;
            base.UnsubscribeEvents();
        }
            
        private void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;
                
            if (_lockedDoors.ContainsKey(ev.Door) && _lockedDoors[ev.Door])
            {
                ev.Player.ShowHint(LanonymousCustomItems.Instance.Translation.Alreadylocked, 2);
                return;
            }
                
            ev.Door.Lock(LockdownDuration, DoorLockType.SpecialDoorFeature);
            _lockedDoors[ev.Door] = true;
                
            Timing.CallDelayed(LockdownDuration, () =>
            {
                if (_lockedDoors.ContainsKey(ev.Door))
                {
                    _lockedDoors[ev.Door] = false;
                }
            });
        }
    }
}