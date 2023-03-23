using CosmosDbExample.Data.Sql;
using CosmosDbExample.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbExample.BusinessLogic
{
    public class InsertProductsInCosmos
    {
        public InsertProductsInCosmos()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            EndpointUri = configuration.GetSection("appSettings")["EndpointUri"];
            PrimaryKey = configuration.GetSection("appSettings")["PrimaryKey"];
        }

        public async Task CreatDbAndInsertData()
        {
            cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "NorthwindProductsExample" });
            await CreateDatabaseAsync();
            await CreateContainerAsync();
            await AddItemsToContainerAsync();
        }

        // The Azure Cosmos DB endpoint for running this sample
        private string EndpointUri;

        // The primary key for the Azure Cosmos account
        private string PrimaryKey;

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create
        private Container container;

        // The name of the database and container 
        private string databaseId = "northwindProducts";
        private string containerId = "products";

        // Create the database if it does not exist
        private async Task CreateDatabaseAsync()
        {
            database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
        }

        // Create the container if it does not exist
        private async Task CreateContainerAsync()
        {
            // Create a new container
            container = await database.CreateContainerIfNotExistsAsync(containerId, "/ProductName");
        }

        private async Task AddItemsToContainerAsync()
        {
            ProductSql productSql = new ProductSql();
            List<Product> productsList = productSql.GetNorthwindProducts();

            foreach (Product product in productsList)
            {
                try
                {
                    // Read the item to see if it exists
                    ItemResponse<Product> productResponse = await container.ReadItemAsync<Product>(product.ProductID, new PartitionKey(product.ProductName));
                }
                catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    try
                    {
                        ItemResponse<Product> productResponse = await container.CreateItemAsync<Product>(product, new PartitionKey(product.ProductName));
                    }
                    catch (CosmosException exc)
                    {
                        Console.WriteLine(exc);
                    }
                }
            }
        }

        private async Task<List<Product>> GetByQueryFromCosmosDB(string query)
        {
            QueryDefinition queryDefinition = new QueryDefinition(query);
            FeedIterator<Product> queryResultSetIterator = container.GetItemQueryIterator<Product>(queryDefinition);

            List<Product> productsList = new List<Product>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Product product in currentResultSet)
                {
                    productsList.Add(product);
                }
            }

            return productsList;
        }

        public async Task<List<Product>> SelectProductsByPrice(string price)
        {
            string query = $"SELECT * FROM c WHERE c.UnitPrice < {price}";
            return await GetByQueryFromCosmosDB(query);
        }


        public async Task<List<Product>> SelectProductsBySupplier(string supplierID)
        {
            string query = $"SELECT * FROM c WHERE c.SupplierID = {supplierID}";
            return await GetByQueryFromCosmosDB(query);
        }

        public async Task<List<Product>> SelectProductsByStartName(string startLetter)
        {        
            string query = $"SELECT * FROM c WHERE STARTSWITH(c.ProductName, '{startLetter}')";
            return await GetByQueryFromCosmosDB(query);
        }
    }
}
