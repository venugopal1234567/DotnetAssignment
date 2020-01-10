using System.Collections.Generic;

namespace Vehicle
{
    class ListVehicles
    {
        public void DisplyInfo(List<Vehicle> vehicles)
        {
            foreach(var vehicle in vehicles)
            {
                vehicle.display();
            }
        }

    }
}
