using Microsoft.Azure.Cosmos;

public class CosmosProvider
{
    public CosmosProvider()
    {
        this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
        Initialize();        
    }
    private async Task Initialize()
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
        this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/study");
    }

    // The Azure Cosmos DB endpoint for running this sample.
    private static readonly string EndpointUri = "https://brunosilvadev.documents.azure.com:443/";
    // The primary key for the Azure Cosmos account.
    private static readonly string PrimaryKey = "1K8T4InsGJmChOtWz5x9RRdj1KyqR6OuNGyhBaVjlQOsaijfAZs8C1vqRdscoPlCxgdj871eLV8Rs5nkLxKvsg==";

    // The Cosmos client instance
    private CosmosClient cosmosClient;

    // The database we will create
    private Database database;

    // The container we will create.
    public Container container;

    // The name of the database and container we will create
    private string databaseId = "study";
    private string containerId = "Container1";

    public string sucesso = "deu bom";

    
}