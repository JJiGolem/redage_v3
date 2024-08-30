using GTANetworkAPI;
using NeptuneEvo.Handles;

namespace NeptuneEvo.Players.Phone.Taxi.Orders
{
    public class Events : Script
    {
        public Events()
        {
            RageEvents.ServerEvents.OnPlayerEnterVehicleEvent += Repository.OnPlayerEnterVehicle;
            RageEvents.ServerEvents.OnPlayerExitVehicleEvent += Repository.OnPlayerExitVehicle;
        }

        [RemoteEvent("server.phone.taxijob.load")]
        public void GetSelect(ExtPlayer player) => Repository.GetSelect(player);

        [RemoteEvent("server.phone.taxijob.take")]
        public void OnTake(ExtPlayer player, int id) => Repository.OnTake(player, id);
    }
}