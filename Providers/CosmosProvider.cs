using Microsoft.Azure.Cosmos;

public class CosmosProvider
{
    public async Task Initialize()
    {
        if(this.cosmosClient == null)
        {
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);                  
        }
        if (this.database == null || this.container == null)
        {
            await InitializeComponents();
        }
    }
    private async Task InitializeComponents()
    {
        await this.CreateDatabaseAsync();

        await this.CreateContainerAsync();
    }
    private async Task CreateDatabaseAsync()
    {
        this.database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
    }

    private async Task CreateContainerAsync()
    {
        this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/Items");
    }

    #region private keys
    // The Azure Cosmos DB endpoint for running this sample.
    private static readonly string EndpointUri = "https://brunosilvadev.documents.azure.com:443/";
    // The primary key for the Azure Cosmos account.
    private static readonly string PrimaryKey = "NF22zjdNOKzKSQiYNVZcoRfCsHhf1WEuh7Yojp3VVQuimqyYZZPcVYk49PyyKpxwKiFZKtnUaIbiE8WkmM3VJg==";

    // The Cosmos client instance
    private CosmosClient cosmosClient;

    // The database we will create
    private Database database;

    // The container we will create.
    public Container container;

    // The name of the database and container we will create
    private string databaseId = "study";
    private string containerId = "Container1";

    #endregion
    
}