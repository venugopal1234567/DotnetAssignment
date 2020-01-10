using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestVehicleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                VehicleClient client = new VehicleClient();

                Console.WriteLine("Hai Wlcome To ShowRoom");
                Console.WriteLine("1. List Vehicle");
                Console.WriteLine("2. Add Vehicle");
                Console.WriteLine("3. Edit Vehicle");
                Console.WriteLine("4. Search Vehicle");
                Console.WriteLine("5. Delete Vehicle");
                int userInput = 0;
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Entered Value is wrong");
                }

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        client.ListVeihicle();
                        break;
                    case 2:
                        Console.Clear();
                        client.AddVehicle();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter Registration number");
                        string rNo2 = Console.ReadLine();
                        client.EditVehicle(rNo2);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter Registration number");
                        string rNo = Console.ReadLine();
                        client.Search(rNo);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter Registration number");
                        string rNo1 = Console.ReadLine();
                        client.DeleteVehicle(rNo1);
                        break;
                    default:
                        Console.WriteLine("You have entered Wrong input");
                        break;
                }




                
            }

        }
    }
}
