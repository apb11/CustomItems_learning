// -----------------------------------------------------------------------
// <copyright file="ImpactFlashGrenade.cs" company="Lanonymous">
// Copyright (c) Lanonymous. All rights reserved.
// Licensed under the CC BY-SA 4.0 license.
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using YamlDotNet.Serialization;

namespace LanonymousCustomItems.CustomItems
{
    public class ImpactFlashGrenade
    {
        [CustomItem(ItemType.GrenadeFlash)]
        public class ImpactFlashGrenadeItem : CustomGrenade
        {
            public ItemType ItemType { get; set; } = ItemType.GrenadeFlash;
            
            public override uint Id { get; set; } = 103;
            
            public override string Name { get; set; } = "Impact Flash Grenade";
            
            public override string Description { get; set; } = "A grenade that explode on collision!";
            
            public override float Weight { get; set; } = 0.5f;
            [YamlIgnore]
            public override bool ExplodeOnCollision { get; set; } = true;
            [YamlIgnore]
            public override float FuseTime { get; set; } = 5;

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
        }
    }
}