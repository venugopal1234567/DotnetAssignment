using System;

namespace Vehicle
{
    public class Cars : Vehicle
    {
        string brand;
        bool AC;
        public Cars( ) : base( )
        {
            Console.WriteLine("Enter brand");
            brand = Console.ReadLine();
            Console.WriteLine("Enter type of AC you Want");
            AC = Boolean.Parse(Console.ReadLine());

        }

        public override void display()
        {
            base.display();
            Console.WriteLine("Your brand is : {0}",brand);
            Console.WriteLine("Type of AC {0}",AC);
        }

        public override string GetRegistrationNum()
        {
            return registrationNum;
        }

        public override void UpdateVehicle()
        {
            Console.Clear();

            display();

            Console.WriteLine(" ");
            Console.WriteLine("Hai you can update following things");
            Console.WriteLine("1.  AC");
            var userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1: Console.WriteLine(" Enter Type of AC you Want Enter  '1' or '0' ");
                    bool acVal = Boolean.Parse( Console.ReadLine());
                    this.AC = acVal;
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
                        
            }
            Console.WriteLine("Successfully Updated");
            Console.WriteLine(" Your current status is");

            display();

            Console.WriteLine(" ");
        }
    }
}
