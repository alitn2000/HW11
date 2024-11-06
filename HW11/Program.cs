
using HW11.UserService;

 IUserService userSevice = new UserService();
bool exit = false;
while (!exit)
{
    Console.WriteLine("\n--- Product Management Menu ---");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Show Products with Category");
    Console.WriteLine("3. Search by Product ID");
    Console.WriteLine("4. Update Product");
    Console.WriteLine("5. Delete Product");
    Console.WriteLine("6. Exit");
    Console.Write("Please choose an option: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
        continue;
    }

    switch (choice)
    {
        case 1:
            userSevice.Add();
            Console.ReadKey();
            Console.Clear();
            break;

        case 2:
            userSevice.ShowWithCategory();
            Console.ReadKey();
            Console.Clear();
            break;

        case 3:
           userSevice.ShowWithId();
            Console.ReadKey();
            Console.Clear();
            break;

        case 4:
            userSevice.UpdateById();
            Console.ReadKey();
            Console.Clear();
            break;

        case 5:
            userSevice.DeleteById();
            Console.ReadKey();
            Console.Clear();
            break;

        case 6:
            exit = true;
            Console.WriteLine("Exiting the program.");
            break;

        default:
            Console.WriteLine("Invalid choice!!!");
            break;
    }
}