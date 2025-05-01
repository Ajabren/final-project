namespace final_project
{
    class Program
    {
        static string[] giftNames = new string[100];
        static string[] giftDescriptions = new string[100];
        static string[] giftBuyers = new string[100];
        static bool[] giftPurchased = new bool[100];
        static int giftCount = 0;

        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Wedding Gift Registry!");
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine() ?? string.Empty;

            bool isNewlyWed = (name == "Antron" || name == "Azale");

            if (isNewlyWed)
            {
                Console.WriteLine($"Welcome, newlywed {name}! You can add gifts to the registry.");
            }
            else
            {
                Console.WriteLine($"Welcome, {name}. You can view and purchase gifts. Ask the newlyweds to add more gifts.");
            }

            RunGiftMenu(isNewlyWed);
        }

        static void RunGiftMenu(bool isNewlyWed)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Wedding Gift Manager ---");
                if (isNewlyWed) Console.WriteLine("1. Add Gift");
                Console.WriteLine("2. Mark Gift as Purchased");
                Console.WriteLine("3. View Gift List");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (isNewlyWed && choice == "1")
                {
                    AddGift();
                }
                else if (choice == "2")
                {
                    MarkAsPurchased();
                }
                else if (choice == "3")
                {
                    ViewGiftList();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Thank you for using the Wedding Gift Manager!");
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        static void AddGift()
        {
            Console.Write("Gift name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();

            giftNames[giftCount] = name;
            giftDescriptions[giftCount] = description;
            giftPurchased[giftCount] = false;
            giftBuyers[giftCount] = "";
            giftCount++;

            Console.WriteLine("Gift added successfully!");
        }

        static void MarkAsPurchased()
        {
            if (!AnyGiftsAvailable())
            {
                Console.WriteLine("All gifts have been purchased. Consider sending money or a card. Thank you!");
                return;
            }

            Console.Write("Enter gift name to purchase: ");
            string name = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < giftCount; i++)
            {
                if (giftNames[i].ToLower() == name.ToLower() && !giftPurchased[i])
                {
                    Console.Write("Buyer's name: ");
                    string buyer = Console.ReadLine();
                    giftPurchased[i] = true;
                    giftBuyers[i] = buyer;
                    Console.WriteLine("Gift marked as purchased!");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Gift not found or already purchased.");
            }
        }

        static void ViewGiftList()
        {
            if (giftCount == 0)
            {
                Console.WriteLine("No gifts have been added yet.");
                return;
            }

            Console.WriteLine("\n--- Gift List ---");
            for (int i = 0; i < giftCount; i++)
            {
                string status = giftPurchased[i] ? $"Purchased by {giftBuyers[i]}" : "Available";
                Console.WriteLine($"{giftNames[i]} - {giftDescriptions[i]} | {status}");
            }
        }

        static bool AnyGiftsAvailable()
        {
            for (int i = 0; i < giftCount; i++)
            {
                if (!giftPurchased[i])
                    return true;
            }
            return false;
        }
    }
}
