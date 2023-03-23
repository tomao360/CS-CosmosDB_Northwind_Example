using CosmosDbExample.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbExample.Data.Sql
{
    public class ProductSql
    {
        public ProductSql()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            connectionString = configuration.GetSection("appSettings")["ConnectionString"];
        }

        private string connectionString;

        public List<Product> GetNorthwindProducts()
        {
            List<Product> productsList = new List<Product>();
            productsList.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("select * from Products", connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();

                                product.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")).ToString();
                                product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                                product.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                                product.CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID"));
                                product.QuantityPerUnit = reader.GetString(reader.GetOrdinal("QuantityPerUnit"));
                                product.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                                product.UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock"));
                                product.UnitsOnOrder = reader.GetInt16(reader.GetOrdinal("UnitsOnOrder"));
                                product.ReorderLevel = reader.GetInt16(reader.GetOrdinal("ReorderLevel"));
                                product.Discontinued = reader.GetBoolean(reader.GetOrdinal("Discontinued"));

                                productsList.Add(product);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message, ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex);
            }

            return productsList;
        }

    }
}
