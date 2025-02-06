
namespace LanonymousCustomItems.Events
{
    using static Exiled.CustomItems.CustomItems;
    
    public class ServerHandler
    {
        public void OnReloadingConfigs()
        {
            LanonymousCustomItems.Instance.Config.LoadItems();
        }
    }
}