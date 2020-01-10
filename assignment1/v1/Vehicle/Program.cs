using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace Vehicle
{

    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            var vehicle = new List<Vehicle>();

           
            

            while (true)
            {

                Console.WriteLine("Welcome to Tesla");
                Console.WriteLine("Choose the FOllowing Options");
                Console.WriteLine("1. List all the vehicles registered");
                Console.WriteLine("2. Add new vehicle");
                Console.WriteLine("3. Edit the vehicle");
                Console.WriteLine("4. Delete vehicle");
                Console.WriteLine("5. Search");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                
                    case 1:
                        Console.WriteLine("See all the registered vehicles");
                        LisRegisteredVehicles();
                        break;

                    case 2:
                        AddNewVehicle();
                        break;
                    case 3:
                        Console.WriteLine("Edit the vehicle");
                        UpdateVehicle();
                        break;
                    case 4:
                        DeleteVehicle();
                        break;
                    case 5:
                        SearchVehicle();
                        break;
                    default:
                        Console.WriteLine("Invalid user Input");
                        break;
                }
            }

    //Method to display All Vehicles

             void LisRegisteredVehicles()
            {
                Console.Clear();
                var listvehicle = new ListVehicles();
                listvehicle.DisplyInfo(vehicle);
                Console.WriteLine(" ");
            }

    //Method to Add new Vehicle

             void AddNewVehicle()
            {
                
                Console.Clear();
                Console.WriteLine("Choose the vehicle type that you want to Addd");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Bus");
                Console.WriteLine("3. Truck");
                var userInput1 = Convert.ToInt32( Console.ReadLine());
                switch (userInput1)
                {
                    case 1: Console.Clear();
                        Console.WriteLine("You have choosen Car");
                        vehicle.Add(new Cars());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You have choosen Bus");
                        vehicle.Add(new Busses());
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("You have choosen Truck");
                       vehicle.Add(new Trucks());
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                
             }

         //Delete Vehicle

            void DeleteVehicle()
            {
                string regNo;
                Console.WriteLine(" ");
                Console.WriteLine("Enter Registration Number to delete");
                regNo = Console.ReadLine();
                int i = 0;
                int count = 0;
                foreach (var vehcl in vehicle)
                {

                    if (vehcl.GetRegistrationNum() == regNo)
                    {
                        vehicle.RemoveAt(i);
                        Console.WriteLine("Successfully removed vehicle");
                        count++;
                        break;
                    }
                    i++;
                }
                if(count != 1)
                {
                    Console.WriteLine("Error occured while deleting");
                }
            }
         
        //Update Vehicle
         void UpdateVehicle()
            {
                string regNo;
                Console.WriteLine(" ");
                Console.WriteLine("Enter Registration Number to Update");
                regNo = Console.ReadLine();
                int i = 0;
                int count = 0;
                foreach (var vehcl in vehicle)
                {

                    if (vehcl.GetRegistrationNum() == regNo)
                    {

                        vehcl.UpdateVehicle();
                        count++;
                        break;
                    }
                    i++;
                }
                if(count != 1)
                {
                    Console.WriteLine("Error Updating Vehicle");
                }

            }

            void SearchVehicle()
            {
                string regNo;
                Console.WriteLine(" ");
                Console.WriteLine("Enter Registration Number to Get Details");
                regNo = Console.ReadLine();
                int i = 0;
                int count = 0;
                foreach (var vehcl in vehicle)
                {

                    if (vehcl.GetRegistrationNum() == regNo)
                    {

                        vehcl.display();
                        count++;
                        break;
                    }
                    i++;
                }
                if (count != 1)
                {
                    Console.WriteLine("Error Updating Vehicle");
                }

            }

        }
        

        
    }
}
