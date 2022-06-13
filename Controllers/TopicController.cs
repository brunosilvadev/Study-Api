using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Study_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    private readonly ILogger<TopicController> _logger;
    private readonly DbAgent _agent;

    public TopicController(ILogger<TopicController> logger, DbAgent agent)
    {
        _logger = logger;
        _agent = agent;
    }

    

    [HttpGet("Topics", Name = "GetTopics")]
    public async Task<List<Topic>> GetTopics()
    {
        return await _agent.GetAllTopicsCosmo();
    }
}
