namespace EShop;

internal class Program
{
    private static void Main()
    {
        var repo = new SqlRepo();
        Console.WriteLine("Welcome to EShop! \n\n (1) See current orders. \n\n (2) See inventory and or create a new order.");
        var input = Console.ReadLine();

        if (input == "1")
        {
            // Code to list product categories goes here
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.WriteLine("Categories:");
            repo.ListCategories();
            var _input= Console.ReadLine();

            if (_input == "1")
            {
                Console.Clear();
                Console.WriteLine("Products:");
                repo.ListCategoriesProducts();
            }


        }
        else
        {
            Console.WriteLine("Invalid option. Please choose 1 or 2.");
        }


    }
}