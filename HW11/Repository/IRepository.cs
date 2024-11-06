using HW11.ENTITIYS;

namespace HW11.Repository;

public interface IRepository
{
    void AddProduct(Product product);
    List<Product> GetAll();
    Product GetByName (string name);
    List <ProductAndCategory> ShowAllProducts();
    ProductAndCategory GetById (int id);
    void DeleteProduct(int id);
    void UpdateProduct(Product product);
}
