

namespace HW11.Querys;

public static class Query
{
    public static string Create = "insert into Products (Name , CategoryId , Price) values (@Name, @CategoryId, @Price)";
    public static string GetAll = "select * from Products";
    public static string GetByName = "select * from Products where Name = @Name";
    public static string ShowAllProducts = "select p.Id as ProductId, p.Name as ProductName, p.Price as ProductPrice, c.Name as CategoryName from Products p join Categories c on p.CategoryId = c.Id";
    public static string GetById = "select p.Id as ProductId, p.Name as ProductName, p.Price  as ProductPrice, c.Name as CategoryName from Products p join Categories c on p.CategoryId = c.Id where p.Id = @ProductId";
    public static string DeleteProduct = "delete from Products where Id = @Id";
    public static string UpdateProduct = "update Products SET Name = @Name, CategoryId = @CategoryId, Price = @Price WHERE Id = @Id";
}
