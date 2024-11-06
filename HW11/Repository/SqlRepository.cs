using HW11.ENTITIYS;
using HW11.Querys;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using HW11.ConnectionString;
using System.Xml.Linq;
using System;

namespace HW11.Repository;

public class SqlRepository : IRepository
{
    public void AddProduct(Product product)
    {

        using (IDbConnection connect = new SqlConnection(Connection.ConnectionString))
        {
            connect.Execute(Query.Create, new { Name = product.Name, CategoryId = product.CategoryId, Price = product.Price });
        }
    }

    public void DeleteProduct(int id)
    {
        using (IDbConnection connect = new SqlConnection(Connection.ConnectionString))
        {
            connect.Execute(Query.DeleteProduct, new { Id = id });
        }
    }

    public List<Product> GetAll()
    {
        using (IDbConnection connect = new SqlConnection(Connection.ConnectionString))
        {
            return connect.Query<Product>(Query.GetAll).ToList();
        }
    }

    public ProductAndCategory GetById(int id)
    {
        using (IDbConnection connect = new SqlConnection(Connection.ConnectionString))
        {
            return connect.QueryFirstOrDefault<ProductAndCategory>(Query.GetById, new { ProductId = id });
        }
    }

    public Product GetByName(string name)
    {
        using (IDbConnection connect = new SqlConnection(Connection.ConnectionString))
        {
            return connect.QueryFirstOrDefault<Product>(Query.GetByName, new { Name = name });
        }
    }

    public List<ProductAndCategory> ShowAllProducts()
    {
        using (IDbConnection connect = new SqlConnection(Connection.ConnectionString))
        {
            return connect.Query<ProductAndCategory>(Query.ShowAllProducts).ToList();
        }
    }

    public void UpdateProduct(Product product)
    {
        using (IDbConnection connect = new SqlConnection(Connection.ConnectionString))
        {
            connect.Execute(Query.UpdateProduct, new{Id = product.Id, Name = product.Name, CategoryId = product.CategoryId, Price = product.Price });
        }
      
    }
}

