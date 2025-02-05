using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerAPI = Exiled.API.Features.Player;
using PlayerEvent = Exiled.Events.Handlers.Player;

namespace LanonymousCustomItems.CustomItems
{
    [CustomItem(ItemType.ArmorHeavy)]
    public class ExplosiveBelt : CustomArmor
    {
        public override ItemType Type { get; set; } = ItemType.ArmorHeavy;
        public override uint Id { get; set; } = 101;
        public override string Name { get; set; } = "Explosive Belt";
        public override string Description { get; set; } = "A belt that explodes when you die.";
        public override float Weight { get; set; } = 1f;

        private readonly List<PlayerAPI> _playersWithArmorOn = new();

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
            PlayerEvent.Dying += OnDeath;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            PlayerEvent.Dying -= OnDeath;
            base.UnsubscribeEvents();
        }

        protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            _playersWithArmorOn.Add(ev.Player);
        }

        protected override void OnDropping(DroppingItemEventArgs ev)
        {
            _playersWithArmorOn.Remove(ev.Player);
        }

        private void OnDeath(DyingEventArgs ev)
        {
            if (_playersWithArmorOn.Contains(ev.Player))
            {
                ev.Player.Explode();
                _playersWithArmorOn.Remove(ev.Player);

                if (LanonymousCustomItems.Instance.Config.EnableInfoLogs)
                {
                    Log.Info($"{ev.Player.Nickname} has exploded!");
                }
            }
        }
    }
}
