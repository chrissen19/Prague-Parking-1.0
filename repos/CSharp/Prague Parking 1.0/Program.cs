using System;

namespace Prague_Parking_1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicleStats = new Vehicle[100];
            string selection = "";
            for (int i = 0; i < vehicleStats.Length; i++)
            {
                Vehicle testCar = new Vehicle();
                vehicleStats[i] = testCar;
                vehicleStats[i].numberPlate = "EMPTY: " + (i + 1).ToString();
            }
            while (true)
            {


                Console.WriteLine("Press 1 to park a vehicle");
                Console.WriteLine("press 2 to remove a parked vehicle");
                Console.WriteLine("press 3 to move a parked vehicle");
                Console.WriteLine("press 4 to show parking spaces");

                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        ParkVehicle(vehicleStats);
                        break;
                    case "2":
                        RemoveVehicle(vehicleStats);
                        break;
                    case "3":
                        MoveVehicle(vehicleStats);
                        break;
                    case "4":
                        SearchVehicle(vehicleStats);
                        break;
                    default:
                        Console.WriteLine("Option not found. Please type a number between 1 & 4.");
                        break;
                }

            }
        }
        static void ParkVehicle(Vehicle[] ArrayToRead)
        {
            Console.Clear();
            Console.WriteLine("Park Vehicle");
            Console.WriteLine("If you have a preffered space type a number between 1-100. Should it be free it is yours, " +
                "however if not then you will be automatically sorted and must choose to move a vehicle in the main menu to get another space.");
            string preferredSpace = Console.ReadLine();
            int preferredSpaceInt = int.Parse(preferredSpace) - 1;
            Console.WriteLine("Specify NumberPlate");
            string numberPlateTemp = Console.ReadLine();
            bool duplicateNumberPlate = false;
            Console.WriteLine("Specify Vehicle type. Car or Motorcycle.");
            string userString = Console.ReadLine();
            bool parked = true;
            if (ArrayToRead[preferredSpaceInt].spacesTaken < 2)
            {
                for (int i = 0; i < ArrayToRead.Length; i++)
                    if (numberPlateTemp == ArrayToRead[i].numberPlate || ArrayToRead[i].numberPlate2 == numberPlateTemp)
                    {
                        Console.WriteLine("This numberPlate is already parked as such please choose another way to write it.");
                        duplicateNumberPlate = true;
                        preferredSpaceInt -= 1;
                    }

                if (duplicateNumberPlate == false)
                {
                    if (userString.ToLower() == "Car".ToLower())
                    {
                        ArrayToRead[preferredSpaceInt].numberPlate = numberPlateTemp;
                        ArrayToRead[preferredSpaceInt].spacesTaken = 2;
                        Console.Clear();
                        Console.WriteLine("Vehicle Parked on space number" + (preferredSpace + 1));

                    }
                    else if ((userString.ToLower() == "MC".ToLower() || userString.ToLower() == "Motorcycle".ToLower()) & ArrayToRead[preferredSpaceInt].spacesTaken == 0)
                    {
                        ArrayToRead[preferredSpaceInt].numberPlate = numberPlateTemp;
                        ArrayToRead[preferredSpaceInt].spacesTaken = 1;
                        Console.Clear();
                        Console.WriteLine("Vehicle Parked on space number" + (preferredSpace + 1));

                    }
                    else if ((userString.ToLower() == "MC".ToLower() || userString.ToLower() == "Motorcycle".ToLower()) & ArrayToRead[preferredSpaceInt].spacesTaken == 1)
                    {
                        ArrayToRead[preferredSpaceInt].numberPlate2 = numberPlateTemp;
                        ArrayToRead[preferredSpaceInt].spacesTaken = 3;
                        Console.Clear();
                        Console.WriteLine("Vehicle Parked on space number " + (preferredSpace + 1.5));

                    }
                }

            }
            else
            {
                parked = false;
            }

            if (parked == false)
                for (int i = 0; i < ArrayToRead.Length; i++)
                {
                    if (ArrayToRead[i].spacesTaken < 2)
                    {
                        for (int i1 = 0; i1 < ArrayToRead.Length; i1++)
                            if (duplicateNumberPlate == false)
                            {
                                if (userString.ToLower() == "Car".ToLower())
                                {
                                    ArrayToRead[i].numberPlate = numberPlateTemp;
                                    ArrayToRead[i].spacesTaken = 2;
                                    Console.Clear();
                                    Console.WriteLine("Vehicle Parked on space number" + (i + 1));
                                    break;
                                }
                                else if ((userString.ToLower() == "MC".ToLower() || userString.ToLower() == "Motorcycle".ToLower()) & ArrayToRead[i].spacesTaken == 0)
                                {
                                    ArrayToRead[i].numberPlate = numberPlateTemp;
                                    ArrayToRead[i].spacesTaken = 1;
                                    Console.Clear();
                                    Console.WriteLine("Vehicle Parked on space number" + (i + 1));
                                    break;
                                }
                                else if ((userString.ToLower() == "MC".ToLower() || userString.ToLower() == "Motorcycle".ToLower()) & ArrayToRead[i].spacesTaken == 1)
                                {
                                    ArrayToRead[i].numberPlate2 = numberPlateTemp;
                                    ArrayToRead[i].spacesTaken = 3;
                                    Console.Clear();
                                    Console.WriteLine("Vehicle Parked on space number " + (i + 1.5));
                                    break;
                                }
                                else if (userString.ToLower() == "cancel")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Type");
                                    i -= 1;
                                }
                            }

                    }
                }


        }
        static void RemoveVehicle(Vehicle[] ArrayToRead)
        {
            Console.Clear();
            Console.WriteLine("remove Vehicle");
            Console.WriteLine("Type your parking number. If it contains a dot depending on your region it may need to be written using a point instead.");
            string parkingNumber = Console.ReadLine();
            for (int i = 0; i < ArrayToRead.Length; i++)
            {
                if ((i + 1).ToString() == parkingNumber)
                {
                    if (ArrayToRead[i].spacesTaken == 1 || ArrayToRead[i].spacesTaken == 2)
                    {
                        ArrayToRead[i].numberPlate = "EMPTY: " + (i + 1).ToString();
                        ArrayToRead[i].spacesTaken = 0;
                        break;
                    }
                    else if (ArrayToRead[i].spacesTaken == 3)
                    {
                        ArrayToRead[i].numberPlate = ArrayToRead[i].numberPlate2;
                        ArrayToRead[i].numberPlate2 = "";
                        ArrayToRead[i].spacesTaken = 1;
                        break;
                    }

                }
                else if ((i + 1.5f).ToString() == parkingNumber)
                {
                    ArrayToRead[i].numberPlate2 = "";
                    ArrayToRead[i].spacesTaken = 1;
                    break;
                }
                Console.WriteLine((i + 1.5f).ToString());

            }
        }
        static void MoveVehicle(Vehicle[] ArrayToRead)
        {
            Console.Clear();
            Console.WriteLine("Move Vehicle");
            Console.WriteLine("Type your parking number");
            string myNumber = Console.ReadLine();
            Console.WriteLine("Type desired parking number");
            string desiredNumber = Console.ReadLine();
            int transformer = int.Parse(desiredNumber) - 1;
            for (int i = 0; i < ArrayToRead.Length; i++)
            {
                if ((i + 1).ToString() == myNumber)
                {
                    if (ArrayToRead[i].spacesTaken == 2 && ArrayToRead[transformer].spacesTaken == 0)
                    {
                        ArrayToRead[transformer].numberPlate = ArrayToRead[i].numberPlate;
                        ArrayToRead[i].numberPlate = "EMPTY: " + (i + 1).ToString();

                        ArrayToRead[transformer].spacesTaken = 2;
                        ArrayToRead[i].spacesTaken = 0;
                        break;
                    }
                    else if (ArrayToRead[i].spacesTaken == 1 && (ArrayToRead[transformer].spacesTaken == 0 || ArrayToRead[transformer].spacesTaken == 1))
                    {
                        if (ArrayToRead[transformer].numberPlate == "EMPTY: " + (transformer + 1).ToString())
                        {
                            ArrayToRead[transformer].numberPlate = ArrayToRead[i].numberPlate;

                            ArrayToRead[transformer].spacesTaken = 1;
                        }
                        else
                        {
                            ArrayToRead[transformer].numberPlate2 = ArrayToRead[i].numberPlate;

                            ArrayToRead[transformer].spacesTaken = 3;
                        }
                        ArrayToRead[i].spacesTaken = 0;

                        ArrayToRead[i].numberPlate = "EMPTY: " + (i + 1).ToString();
                        break;
                    }
                    else if (ArrayToRead[i].spacesTaken == 3 && (ArrayToRead[transformer].spacesTaken == 0 || ArrayToRead[transformer].spacesTaken == 1))
                    {
                        if (ArrayToRead[transformer].numberPlate == "EMPTY: " + (transformer + 1).ToString())
                        {
                            ArrayToRead[transformer].numberPlate = ArrayToRead[i].numberPlate;

                            ArrayToRead[transformer].spacesTaken = 1;
                        }
                        else
                        {
                            ArrayToRead[transformer].numberPlate2 = ArrayToRead[i].numberPlate;

                            ArrayToRead[transformer].spacesTaken = 3;
                        }
                        ArrayToRead[i].spacesTaken = 1;

                        ArrayToRead[i].numberPlate = ArrayToRead[i].numberPlate2;
                        ArrayToRead[i].numberPlate2 = "";
                        break;
                    }

                }
                else if ((i + 1.5f).ToString() == myNumber)
                {
                    if (ArrayToRead[transformer].numberPlate == "EMPTY: " + (transformer + 1).ToString())
                    {
                        ArrayToRead[transformer].numberPlate = ArrayToRead[i].numberPlate2;

                        ArrayToRead[transformer].spacesTaken = 1;
                    }
                    else
                    {
                        ArrayToRead[transformer].numberPlate2 = ArrayToRead[i].numberPlate2;

                        ArrayToRead[transformer].spacesTaken = 3;
                    }
                    ArrayToRead[i].spacesTaken = 1;

                    ArrayToRead[i].numberPlate2 = "";
                    break;
                }

            }

        }

        static void SearchVehicle(Vehicle[] ArrayToRead)
        {
            Console.Clear();
            Console.WriteLine("Search Vehicle");
            //Write out the entire parkingLot
            for (int i = 0; i < ArrayToRead.Length; i++)
            {
                string ID = ArrayToRead[i].numberPlate;
                string ID2 = ArrayToRead[i].numberPlate2;

                if (ID != null)
                {
                    if (i % 10 == 0)
                        Console.WriteLine("");
                    if (ArrayToRead[i].spacesTaken == 3)
                    {
                        Console.Write("[" + ID + " " + ID2 + "] ");
                    }
                    else
                        Console.Write(ID + " ");
                }

                else if (ID == "")
                    Console.Write(ID + " ");
                else
                {
                    Console.WriteLine("Error in write");
                    break;
                }
            }

            Console.WriteLine("");
        }
    }
    public class Vehicle
    {
        public string numberPlate = "XYZ987";
        public string numberPlate2 = "";
        public int spacesTaken = 0;
    }

}
