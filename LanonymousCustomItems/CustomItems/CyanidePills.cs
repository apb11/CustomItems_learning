using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using MEC;


namespace LanonymousCustomItems.CustomItems
{
    public class CyanidePills
    {
        [CustomItem(ItemType.Painkillers)]
        public class CyanidePill : CustomItem
        {
            public override uint Id { get; set; } = 100;
            public override string Name { get; set; } = "Cyanide Pills";
            public override string Description { get; set; } = "A pill to kill yourself if needed.";
            public override float Weight { get; set; } = 0.5f;
            public ItemType ItemType { get; set; } = ItemType.Painkillers;
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
                    ev.Player.Kill("Dead by cyanide pills...");
                });
            }
        }
    }
}