using System;
using System.Collections.Generic;
using System.Reflection;

namespace TheBestVehicleFactory
{
    class VehicleClient
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        Bus bus = new Bus();
        Car car = new Car();
        Scooty scooty = new Scooty();
        MotorCycle motorCycle = new MotorCycle();


       static List<object> vehiclDatabe = new List<object>();

        public VehicleClient()
        {
            vehicles.Add(bus);
            vehicles.Add(car);
            vehicles.Add(scooty);
            vehicles.Add(motorCycle);
        }
       

        public void ListVeihicle()
        {
            if(vehiclDatabe.Count == 0)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            foreach(object obj in vehiclDatabe)
            {
                Console.WriteLine(obj.GetType().Name);
                Type T = Type.GetType("TheBestVehicleFactory." + obj.GetType().Name);
                PropertyInfo[] properties = T.GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    Console.WriteLine(property.Name+ " " + property.GetValue(obj));
                }
                Console.WriteLine();
            }
        }


        public void AddVehicle()
        {
         
                int i = 1;
                foreach (object obj in vehicles)
                {
                    System.Console.WriteLine(i + ". " + obj.GetType().Name);
                    i++;
                }

                //List All Vehicle Types

                System.Console.WriteLine("ENter which one you want to Add");
                int userInput = 0;
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please Enter the correct value !!!!!!!!!!!!!!");
                    return;
                }


                if (userInput > i)
                {
                    Console.WriteLine("You have choosen wrong option!!!!!!!!!!!!!!!!");
                    return;
                }

                Type T = Type.GetType("TheBestVehicleFactory." + vehicles[userInput - 1].GetType().Name);
                PropertyInfo[] properties = T.GetProperties();

                Console.WriteLine();
                Console.WriteLine("Properties of " + vehicles[userInput - 1].GetType().Name);
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(property.Name);
                }

                //Setting Property of Vehicle

                object vehicleInstance = Activator.CreateInstance(T);
                Console.WriteLine(" Enter One by one values to Add  the properties of vehicle");
                PropertyInfo[] properties1 = T.GetProperties();

                foreach (PropertyInfo propertyo in properties1)
                {
                    Console.WriteLine("Specify the value of   " + propertyo.Name + " Its type is " + propertyo.PropertyType.Name);
                    var userInput1 = Console.ReadLine();
                    try
                    {
                        PropertyInfo propertyInfo = vehicleInstance.GetType().GetProperty(propertyo.Name);
                        propertyInfo.SetValue(vehicleInstance, Convert.ChangeType(userInput1, propertyInfo.PropertyType), null);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(" Please Enter valid value ");
                        return;
                    }

                }
                vehiclDatabe.Add(vehicleInstance);

            

        }



        public void EditVehicle(string rNo2)
        {
            int count = 0;
            foreach (Vehicle obj in vehiclDatabe)
            {
                if (obj.RegisterNumber == rNo2)
                {
                        List<String> propertiesList = new List<string>();
                        Type T = Type.GetType("TheBestVehicleFactory." + vehiclDatabe[count].GetType().Name);
                        PropertyInfo[] properties = T.GetProperties();

                    // Console.WriteLine(properties[0]);
                        int count1 = 1;
                        foreach (PropertyInfo property in properties)
                        {
                            Console.WriteLine(count1+".  "+property.Name + " =>>>>   "+ property.GetValue(vehiclDatabe[count]));
                            propertiesList.Add(property.Name);
                            count1++;
                        }

                       Console.WriteLine("Choose Which one U want to edit");
                       int userInput1 = 0;
                       try
                        {
                         userInput1 = Convert.ToInt32(Console.ReadLine());
                         }
                        catch (Exception)
                         {
                          Console.WriteLine("Please choose the correct option ");
                          return;
                          }
                       

                       Console.WriteLine("Enter the value of " + propertiesList[userInput1-1] );
                       var userInput2 = Console.ReadLine();
                    try
                    {
                        PropertyInfo propertyInfo = vehiclDatabe[count].GetType().GetProperty(propertiesList[userInput1 - 1]);
                        propertyInfo.SetValue(vehiclDatabe[count], Convert.ChangeType(userInput2, propertyInfo.PropertyType), null);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter valid value");
                    }

                    break;

                }
                else
                {
                    Console.WriteLine("The vehicle does not Exist in the Database");
                }
                count++;
            }

        }


        public void Search(string regiNo)
        {
           foreach(Vehicle obj in vehiclDatabe)
            {
                if(obj.RegisterNumber == regiNo)
                {

                    Console.WriteLine("Yes We found the Vehicle");
                    Type T = Type.GetType("TheBestVehicleFactory." + obj.GetType().Name);
                    PropertyInfo[] properties = T.GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        Console.WriteLine(property.Name + " " + property.GetValue(obj));
                    }
                    break;
                }
            }


        }

        public void DeleteVehicle(string regiNo)
        {
            int count = 0;
            foreach (Vehicle obj in vehiclDatabe)
            {
                if (obj.RegisterNumber == regiNo)
                {
                    vehiclDatabe.RemoveAt(count);
                    Console.WriteLine("Succeessfully removed");
                    break;
                }
                count++;
            }

        }

    }
}
