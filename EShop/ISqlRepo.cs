namespace EShop;

internal interface ISqlRepo
{
    void ListCategories();

    void ListCategoriesProducts();

    void ListOrders();

    void AddOrder();
}