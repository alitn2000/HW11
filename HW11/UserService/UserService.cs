using HW11.ENTITIYS;
using HW11.Repository;
using System.Diagnostics;
using System.Xml.Linq;

namespace HW11.UserService;

public class UserService : IUserService
{
    private readonly IRepository Sql = new SqlRepository();
    public void Add()
    {
        Product product = null;

        Console.Write("Enter Product Name:");
        var Name = Console.ReadLine();
        Console.Write(" Enter Product Category: ( 1.Electronics 2.Accessories 3.Peripherals 4.Clothing )");
        if (!int.TryParse(Console.ReadLine(), out int Category))
        {
            Console.WriteLine("Invalid input for Category!!!");
            return;
        }
        Console.Write("Enter Price:");
        if (!int.TryParse(Console.ReadLine(), out int Price))
        {
            Console.WriteLine("Invalid input for Price!!!");
            return;
        }
        product = new Product(Name, Category, Price);

        var exist = Sql.GetByName(product.Name);
        if (exist != null)
        {

            if (exist.CategoryId == product.CategoryId)
            {
                Console.WriteLine("The Item exist with Your selected Category");
            }
            else
            {
                Sql.AddProduct(product);
            }

        }
        else
        {
            Sql.AddProduct(product);
        }


    }

    public void DeleteById()
    {
        Console.Write("Enter Product Id:");
        if (!int.TryParse(Console.ReadLine(), out int Id))
        {
            Console.WriteLine("Invalid input for Category!!!");
            return;
        }
        var exist = Sql.GetById(Id);

        if (exist != null)
        {
            Sql.DeleteProduct(exist.ProductId);
            Console.WriteLine("Product removed.");
        }

        else
        {
            Console.WriteLine("Product not Found!!!");
        }

    }

    public void ShowWithCategory()
    {
        var products = Sql.ShowAllProducts();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.ProductId}- {p.ProductName}: {p.ProductPrice} ({p.CategoryName})");
        }
    }

    public void ShowWithId()
    {
        Console.WriteLine("Enter product Id");
        var Id = int.Parse(Console.ReadLine());
        var exist = Sql.GetById(Id);

        if (exist != null)
        {
            Console.WriteLine($"{exist.ProductId}- {exist.ProductName}: {exist.ProductPrice} ({exist.CategoryName})");
        }
        else
        {
            Console.WriteLine("Product not found!!!");
            return;
        }

    }

    public void UpdateById()
    {
        Console.Write("Enter Product Id: ");
        if (!int.TryParse(Console.ReadLine(), out int Id))
        {
            Console.WriteLine("Invalid input for Id!!!");
            return;
        }

        var products = Sql.GetAll();
        var product = products.FirstOrDefault(p => p.Id == Id);
        if (product == null)
        {
            Console.WriteLine("Product not Found!!!");
            return;
        }

        bool continuee = true;
        while (continuee)
        {
            Console.WriteLine("Current Product Details:");
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, CategoryId: {product.CategoryId}, Price: {product.Price}");

            Console.WriteLine("Which part do you want to update? 1.Name 2.CategoryId 3.Price 4.Finish Editing");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new name: ");
                    product.Name = Console.ReadLine();
                    break;

                case 2:
                    Console.Write("Enter new CategoryId (1.Electronics 2.Accessories 3.Peripherals 4.Clothing): ");
                    if (int.TryParse(Console.ReadLine(), out int newCategoryId))
                    {
                        product.CategoryId = newCategoryId;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for CategoryId.");
                    }
                    break;

                case 3:
                    Console.Write("Enter new Price: ");
                    if (int.TryParse(Console.ReadLine(), out int newPrice))
                    {
                        product.Price = newPrice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Price!!!");
                    }
                    break;

                case 4:
                    continuee = false;
                    Console.WriteLine("Edditing finished.");
                    break;

                default:
                    Console.WriteLine("Invalid choice!!!");
                    break;
            }

            if (continuee)
            {
                Sql.UpdateProduct(product);
                Console.WriteLine("Product updated successfully.");
            }
        }
    }
}
