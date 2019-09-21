using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class AdoNetProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                //SportsStore
                //Data Source =.\SQLExpress; Initial Catalog = StortsStore; Integrated Security = True
                var conn = new SqlConnection("Data Source=10.28.33.11;Initial Catalog=TestWut;Persist Security Info=True;User ID=sa;Password=p@$$w0rd");
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Products";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Product
                            {
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                Category = reader.GetString(reader.GetOrdinal("Category"))
                            };
                        }
                    }
                }
            }
        }

        public Product DeleteProduct(int productID)
        {
            var conn = new SqlConnection("Data Source=10.28.33.11;Initial Catalog=TestWut;Persist Security Info=True;User ID=sa;Password=p@$$w0rd");
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 1 * FROM Products WHERE ProductId = @ProductId";
                cmd.Parameters.AddWithValue("@ProductId", productID);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    conn.Close();
                    if (reader != null)
                    {
                        conn.Open();
                        using (var cmd2 = conn.CreateCommand())
                        {
                            cmd2.CommandText = "DELETE FROM Products WHERE ProductId = @ProductId";
                            cmd2.Parameters.AddWithValue("@ProductId", productID);
                            cmd2.ExecuteNonQuery();
                        }
                    }
                    return new Product { Name = "ProductId " + productID };
                }
            }
        }

        public void SaveProduct(Product product)
        {
            var conn = new SqlConnection("Data Source=10.28.33.11;Initial Catalog=TestWut;Persist Security Info=True;User ID=sa;Password=p@$$w0rd");
            if (product.ProductID == 0)
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Products(Name, Description, Category, Price) " +
                        "VALUES(@Name, @Description, @Category, @Price)";
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Category", product.Category);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Products WHERE ProductId = @ProductId";
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductID);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        conn.Close();
                        if (reader != null)
                        {
                            conn.Open();
                            using (var cmd2 = conn.CreateCommand())
                            {
                                cmd2.CommandText = "UPDATE Products SET Name = @Name, Description = @Description, "
                                    + "Price = @Price, Category = @Category WHERE ProductId = @ProductId";
                                cmd2.Parameters.AddWithValue("@ProductId", product.ProductID);
                                cmd2.Parameters.AddWithValue("@Name", product.Name);
                                cmd2.Parameters.AddWithValue("@Description", product.Description);
                                cmd2.Parameters.AddWithValue("@Price", product.Price);
                                cmd2.Parameters.AddWithValue("@Category", product.Category);
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}
