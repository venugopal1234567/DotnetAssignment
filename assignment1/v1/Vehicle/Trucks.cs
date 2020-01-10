using System;

namespace Vehicle
{
    public class Trucks : Vehicle
    {
        readonly string brand;
        public Trucks() : base()
        {
            Console.WriteLine("Enter brand");
            brand = Console.ReadLine();
        }

        public override void display()
        {
            base.display();
            Console.WriteLine("Your Truck brand is {0}", brand);
        }
        public override string GetRegistrationNum()
        {
            return registrationNum;
        }

        public override void UpdateVehicle()
        {
            
        }
    }
}
