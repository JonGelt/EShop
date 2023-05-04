using System.Data.SqlClient;

namespace EShop;

internal class SqlRepo : ISqlRepo
{
    private readonly string connectionString = "Data Source=DESKTOP-VISKDK0\\SQLEXPRESS;Initial Catalog=SEBDB;Integrated Security=True";

    public void ListCategories()
    {
        string query = "SELECT CategoryID, Name, * FROM Categories GROUP BY CategoryID, Name;";
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(query, connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {

            string name = (string)reader["Name"];
            int id = (int)reader["CategoryID"];


            Console.WriteLine($" \n ({id}) for {name}");
        }
        reader.Close();


    }

    public void ListCategoriesProducts()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string spq = "SELECT p.Name, p.Price, c.Name AS CategoryName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID ORDER BY p.ProductID";
            SqlCommand command = new SqlCommand(spq, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Name\t\t\tPrice\t\t\tCategory Name");
            while (reader.Read())
            {


                string name = (string)reader["Name"];
                decimal price = (decimal)reader["Price"];
                string categoryName = (string)reader["CategoryName"];

                Console.WriteLine(name + "\t\t\t" + price + "\t\t\t" + categoryName);
            }
            reader.Close();
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