namespace EShop;

internal interface ISqlRepo
{
    void ListCategories();

    void ListCategoriesProducts(int input);

    void ListOrders();

    void AddOrder();
}