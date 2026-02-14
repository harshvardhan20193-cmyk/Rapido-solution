using System;
using System.Collections.Generic;

class Program
{
    // Dictionary to store registered users
    static Dictionary<string, string> users = new Dictionary<string, string>();

    // List to store booking history
    static List<Dictionary<string, object>> history = new List<Dictionary<string, object>>();

    //    // FUNCTION TO REGISTER USER

    static void RegisterUser()
    {
        Console.WriteLine("\n--- USER REGISTRATION ---");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Mobile Number: ");
        string mobile = Console.ReadLine();

        if (users.ContainsKey(mobile))
        {
            Console.WriteLine("User already registered!\n");
        }
        else
        {
            users[mobile] = name;
            Console.WriteLine("Registration Successful!\n");
        }
    }


    // FUNCTION TO BOOK RIDE
    static void BookRide()
    {
        Console.WriteLine("\n--- BOOK A RIDE ---");
        Console.Write("Enter Registered Mobile Number: ");
        string mobile = Console.ReadLine();

        if (!users.ContainsKey(mobile))
        {
            Console.WriteLine("User not found! Please register first.\n");
            return;
        }

        Console.WriteLine("\n--- SELECT VEHICLE ---");
        Console.WriteLine("1. Bike  (Rs.8 per km)");
        Console.WriteLine("2. Auto  (Rs.12 per km)");
        Console.WriteLine("3. Cab   (Rs.18 per km)");

        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter distance in km: ");
        double distance = Convert.ToDouble(Console.ReadLine());

        int rate = 0;
        string vehicle = "";

        if (choice == 1)
        {
            rate = 8;
            vehicle = "Bike";
        }
        else if (choice == 2)
        {
            rate = 12;
            vehicle = "Auto";
        }
        else if (choice == 3)
        {
            rate = 18;
            vehicle = "Cab";
        }
        else
        {
            Console.WriteLine("Invalid option!\n");
            return;
        }

        double fare = rate * distance;

        Console.WriteLine("\n--- RIDE DETAILS ---");
        Console.WriteLine("Name: " + users[mobile]);
        Console.WriteLine("Vehicle: " + vehicle);
        Console.WriteLine("Distance: " + distance + " km");
        Console.WriteLine("Fare: Rs. " + fare);

        // Save booking history
        history.Add(new Dictionary<string, object>
        {
            { "Name", users[mobile] },
            { "Mobile", mobile },
            { "Vehicle", vehicle },
            { "Distance", distance },
            { "Fare", fare }
        });

        Console.WriteLine("\nRide booked successfully!\n");
    }


    // FUNCTION TO VIEW BOOKING HISTORY

    static void ViewHistory()
    {
        Console.WriteLine("\n--- BOOKING HISTORY ---");

        if (history.Count == 0)
        {
            Console.WriteLine("No bookings found!\n");
        }
        else
        {
            int i = 1;
            foreach (var booking in history)
            {
                Console.WriteLine("\nBooking " + i++);
                Console.WriteLine("---------------------");
                Console.WriteLine("Name: " + booking["Name"]);
                Console.WriteLine("Mobile: " + booking["Mobile"]);
                Console.WriteLine("Vehicle: " + booking["Vehicle"]);
                Console.WriteLine("Distance: " + booking["Distance"] + " km");
                Console.WriteLine("Fare: Rs. " + booking["Fare"]);
            }
        }
    }


    // FUNCTION TO CANCEL LAST RIDE

    static void CancelLastRide()
    {
        Console.WriteLine("\n--- CANCEL LAST RIDE ---");

        if (history.Count == 0)
        {
            Console.WriteLine("No ride to cancel!\n");
        }
        else
        {
            var removed = history[history.Count - 1];
            history.RemoveAt(history.Count - 1);

            Console.WriteLine("Last ride cancelled successfully!");
            Console.WriteLine("Name: " + removed["Name"]);
            Console.WriteLine("Vehicle: " + removed["Vehicle"]);
            Console.WriteLine("Fare: Rs. " + removed["Fare"] + "\n");
        }
    }


    // FUNCTION TO UPDATE USER

    static void UpdateUser()
    {
        Console.WriteLine("\n--- UPDATE USER DETAILS ---");
        Console.Write("Enter Registered Mobile Number: ");
        string mobile = Console.ReadLine();

        if (!users.ContainsKey(mobile))
        {
            Console.WriteLine("User not found!\n");
        }
        else
        {
            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();
            users[mobile] = newName;
            Console.WriteLine("Name updated successfully!\n");
        }
    }


    // FUNCTION TO DELETE USER

    static void DeleteUser()
    {
        Console.WriteLine("\n--- DELETE USER ---");
        Console.Write("Enter Mobile Number: ");
        string mobile = Console.ReadLine();

        if (users.ContainsKey(mobile))
        {
            users.Remove(mobile);
            Console.WriteLine("User deleted successfully!\n");
        }
        else
        {
            Console.WriteLine("User not found!\n");
        }
    }




    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("     ONLINE RAPIDO SYSTEM");

            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Book Ride");
            Console.WriteLine("3. View Booking History");
            Console.WriteLine("4. Cancel Last Ride");
            Console.WriteLine("5. Update User Name");
            Console.WriteLine("6. Delete User");
            Console.WriteLine("7. Exit");
            Console.WriteLine("=================================");

            Console.Write("Enter your choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    RegisterUser();
                    break;
                case 2:
                    BookRide();
                    break;
                case 3:
                    ViewHistory();
                    break;
                case 4:
                    CancelLastRide();
                    break;
                case 5:
                    UpdateUser();
                    break;
                case 6:
                    DeleteUser();
                    break;
                case 7:
                    Console.WriteLine("\nThank you for using Online Rapido!");
                    Console.WriteLine("Have a safe journey!\n");
                    return;
                default:
                    Console.WriteLine("Invalid option! Try again.\n");
                    break;
            }
        }
    }
}
