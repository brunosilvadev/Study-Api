using Microsoft.AspNetCore.Mvc;

namespace Study_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    private readonly ILogger<TopicController> _logger;
    private readonly CosmosDbAgent _agent;
    private readonly LiteDbAgent _liteAgent;

    public TopicController(ILogger<TopicController> logger, CosmosDbAgent agent, LiteDbAgent liteAgent)
    {
        _logger = logger;
        _agent = agent;
        _liteAgent = liteAgent;
    }    

    [HttpGet("Topics", Name = "GetTopics")]
    public async Task<List<Topic>> GetTopics()
    {
        return await _agent.GetAllTopicsCosmo();
    }
    [HttpGet("AllTopics", Name ="GetAllTopics")]
    public List<Topic> GetAllTopic()
    {
        return _liteAgent.GetAllTopics();
    }
    [HttpPost("InsertTopic", Name ="InsertTopic")]
    public int InsertTopic(string topicName)
    {
        return _liteAgent.InsertTopic(new Topic() { Name = topicName });
    }
    [HttpDelete("DeleteTopic", Name ="DeleteTopic")]
    public void DeleteTopic(int id)
    {
        _liteAgent.DeleteTopic(id);
    }
}
