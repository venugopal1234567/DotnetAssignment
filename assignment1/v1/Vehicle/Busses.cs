using System;

namespace Vehicle
{
    public class Busses : Vehicle
    {

        string brand;
        public Busses() : base()
        {
            Console.WriteLine("Enter brand");
            brand = Console.ReadLine();
        }

        public override void display()
        {
            base.display();
            System.Console.WriteLine("your Bus brand is {0}", brand);
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
