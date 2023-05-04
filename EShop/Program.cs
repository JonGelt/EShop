namespace EShop;

internal class Program
{   
    private static void Main()
    {
        var _repo = new SqlRepo();
        Console.WriteLine("Welcome to EShop! \n\n (1) See current orders. \n\n (2) See inventory and or create a new order.");
        var result = Console.ReadLine();

        if (result == "1")
        {
            // Code to list product categories goes here
        }
        else if (result == "2")
        {
            Console.Clear();
           _repo.ListCategories();
        }
        else
        {
            Console.WriteLine("Invalid option. Please choose 1 or 2.");
        }


    }
}