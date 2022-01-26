using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;



public class DbAgent
{
    private readonly ILogger<DbAgent> _logger;
    private CosmosProvider _provider;
    public DbAgent(ILogger<DbAgent> logger, CosmosProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    public async Task<List<Topic>> GetAllTopics()
    {
        Task.Run(async () => { await _provider.Initialize(); }).Wait();
        var sqlQueryText = "SELECT * FROM c WHERE c.id = '2'";
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
