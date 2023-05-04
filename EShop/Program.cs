namespace EShop;

internal class Program
{
    private static void Main()
    {
        var repo = new SqlRepo();
        Console.WriteLine("\u001b[1mWelcome to EShop!\u001b[0m");
        Console.WriteLine(" \n(1) See current orders. \n\n(2) See inventory and or create a new order.");
        var input = Console.ReadLine();

        if (input == "1")
        {
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.WriteLine("\u001b[1mCategories:\u001b[0m");

            repo.ListCategories();
            var _input = Convert.ToInt32(Console.ReadLine());

            if (_input == 1)
            {
                Console.Clear();
                repo.ListCategoriesProducts(_input);
            }
            else if (_input == 2)
            {
                Console.Clear();
                repo.ListCategoriesProducts(_input);
            }

            else if (_input == 3)
            {
                Console.Clear();
                repo.ListCategoriesProducts(_input);
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose 1 or 2.");
            }
        }
        else
        {
            Console.WriteLine("Invalid option. Please choose 1 or 2.");
        }
    }
}