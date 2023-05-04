using System.Data.SqlClient;

namespace EShop;

internal class SqlRepo : ISqlRepo
{
    private readonly string connectionString = "Data Source=DESKTOP-VISKDK0\\SQLEXPRESS;Initial Catalog=SEBDB;Integrated Security=True";

    public void ListCategories()
    {
        var scq = "SELECT CategoryID, Name, * FROM Categories GROUP BY CategoryID, Name;";
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(scq, connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var name = (string)reader["Name"];
            var id = (int)reader["CategoryID"];
            var category = new Category();
            var categories = new List<Category>();

            category.CategoryId = id;
            category.CategoryName = name;
            categories.Add(category);

            foreach (var _category in categories)
                Console.WriteLine("\n{0,-5}{1}", "(" + _category.CategoryId + ")", _category.CategoryName);
        }


        reader.Close();
    }

    public void ListCategoriesProducts(int input)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var scq = $"SELECT c.Name FROM Categories c WHERE c.CategoryID = {input} ";
            var spq = $"SELECT p.ProductID, p.Name, p.Price FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID WHERE p.CategoryID = {input}";
            var spqcommand = new SqlCommand(spq, connection);
            var scqcommand = new SqlCommand(scq, connection);

            var scqreader = scqcommand.ExecuteReader();

            while (scqreader.Read())
            {
                var name = (string)scqreader["Name"];
                Console.WriteLine($"\u001b[1mProducts in {name}:\u001b[0m");
            }

            scqreader.Close();

            Console.WriteLine($"\n\u001b[1m{"  Name:",-23}\t{"   Price:",-10}\u001b[0m\n");
            var spqreader = spqcommand.ExecuteReader();
            while (spqreader.Read())
            {
                var id = (int)spqreader["ProductID"];
                var name = (string)spqreader["Name"];
                var price = (decimal)spqreader["Price"];
                var product = new Product();
                var products = new List<Product>();
                product.Id = id;
                product.Name = name;
                product.Price = price;
                products.Add(product);

                foreach (var p in products) Console.WriteLine($"  {p.Name,-25}{p.Price,-10}");
                //Console.WriteLine(" {0}\t\t\t{1}\n", name, price);
            }

            spqreader.Close();
        }
    }

    public void AddOrder()
    {
        throw new NotImplementedException();
    }

    public void ListOrders()
    {
        throw new NotImplementedException();
    }
}