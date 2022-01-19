using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Study_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    private readonly ILogger<TopicController> _logger;
    private CosmosProvider _provider;

    public TopicController(ILogger<TopicController> logger, CosmosProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    

    [HttpGet("Topics", Name = "GetTopics")]
    public async Task<List<Topic>> GetTopics()
    {
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
