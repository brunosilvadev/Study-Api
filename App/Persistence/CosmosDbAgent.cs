using Microsoft.Azure.Cosmos;



public class CosmosDbAgent
{
    private readonly ILogger<CosmosDbAgent> _logger;
    private CosmosProvider _provider;
    public CosmosDbAgent(ILogger<CosmosDbAgent> logger, CosmosProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    private const string sqlQueryText = "SELECT * FROM c WHERE c.id = '2'";
    public async Task<List<Topic>> GetAllTopicsCosmo()
    {
        Task.Run(async () => { await _provider.Initialize(); }).Wait(); 
        QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
        FeedIterator<Topic> queryResultSetIterator = _provider.container.GetItemQueryIterator<Topic>(queryDefinition);        
        
        List<Topic> topics = new List<Topic>();

        while (queryResultSetIterator.HasMoreResults)
        {
            FeedResponse<Topic> currentResultSet =  await queryResultSetIterator.ReadNextAsync();
            foreach (Topic topic in currentResultSet)
            {
                topics.Add(topic);
            }
        }

        return topics;
    }
}