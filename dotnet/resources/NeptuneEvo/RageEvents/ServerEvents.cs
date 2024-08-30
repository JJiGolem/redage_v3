using GTANetworkAPI;
using NeptuneEvo.Handles;

namespace NeptuneEvo.RageEvents
{
    public class ServerEvents : Script
    {
        public delegate void OnPlayerEnterVehicle(ExtPlayer player, ExtVehicle vehicle, sbyte seat);
        public delegate void OnPlayerExitVehicle(ExtPlayer player, ExtVehicle vehicle);

        public static event OnPlayerEnterVehicle OnPlayerEnterVehicleEvent;
        public static event OnPlayerExitVehicle OnPlayerExitVehicleEvent;

        [ServerEvent(Event.PlayerEnterVehicle)]
        private void OnPlayerEnterVehicleHandler(Player player, Vehicle vehicle, sbyte seat)
        {
            ExtPlayer extPlayer = player as ExtPlayer;
            ExtVehicle extVehicle = vehicle as ExtVehicle;

            OnPlayerEnterVehicleEvent?.Invoke(extPlayer, extVehicle, seat);
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        private void OnPlayerExitVehicleHandler(Player player, Vehicle vehicle)
        {
            ExtPlayer extPlayer = player as ExtPlayer;
            ExtVehicle extVehicle = vehicle as ExtVehicle;

            OnPlayerExitVehicleEvent?.Invoke(extPlayer, extVehicle);
        }
    }
}
