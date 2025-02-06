using System.Collections.Generic;
using System.ComponentModel;
using LanonymousCustomItems.CustomItems;

namespace LanonymousCustomItems.Configs
{
    public class Items
    {
        [Description("Enables Custom Items")]
        public bool IsEnabled { get; set; } = true;

        public List<CyanidePill.CyanidePillItem> CyanidePills { get; private set; } = new()
        {
            new CyanidePill.CyanidePillItem()
        };

        public List<ExplosiveBelt.ExplosiveBeltItem> ExplosiveBelts { get; private set; } = new()
        {
            new ExplosiveBelt.ExplosiveBeltItem()
        };

        public List<ImpactHeGrenade.ImpactHeGrenadeItem> ImpactHeGrenades { get; private set; } = new()
        {
            new ImpactHeGrenade.ImpactHeGrenadeItem()
        };
        
        public List<ImpactFlashGrenade.ImpactFlashGrenadeItem> ImpactFlashGrenades { get; private set; } = new()
        {
            new ImpactFlashGrenade.ImpactFlashGrenadeItem()
        };        
        
        public List<SniperRifle.SniperRifleItem> SniperRifles { get; private set; } = new()
        {
            new SniperRifle.SniperRifleItem()
        };
        
        public List<HackingDevice.HackingDeviceItem> HackingDevices { get; private set; } = new()
        {
            new HackingDevice.HackingDeviceItem()
        };
    }
}
