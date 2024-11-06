namespace HW11.ENTITIYS;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int Price { get; set; }

    public Product(string name, int categoryid, int price)
    {
        Name = name;
        CategoryId = categoryid;
        Price = price;
    }
    public Product() { }
}
