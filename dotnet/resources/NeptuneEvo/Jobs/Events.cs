using GTANetworkAPI;

namespace NeptuneEvo.Jobs
{
    public class Events : Script
    {
        public Events()
        {
            RageEvents.ServerEvents.OnPlayerEnterVehicleEvent += Repository.OnPlayerEnterVehicle;
            RageEvents.ServerEvents.OnPlayerExitVehicleEvent += Repository.OnPlayerExitVehicle;
        }
    }
}