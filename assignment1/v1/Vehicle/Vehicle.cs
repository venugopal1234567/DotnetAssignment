using System;

namespace Vehicle
{
    public class Vehicle
    {
        public readonly string registrationNum;
        public readonly string model;
        public Vehicle()
        {
            Console.WriteLine("Enter Registration Number");
            registrationNum = Console.ReadLine();
            Console.WriteLine("Enter Model number");
            model = Console.ReadLine();
        }
        
        public virtual void display()
        {
            Console.WriteLine("Registration no: {0}",registrationNum);
            Console.WriteLine( "Model number: {0}",model);

        }

        public virtual string GetRegistrationNum()
        {
            return null;
        }
        public virtual void UpdateVehicle()
        {

        }

    }
}
