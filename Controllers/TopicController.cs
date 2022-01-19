using Microsoft.AspNetCore.Mvc;

namespace Study_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    private readonly ILogger<TopicController> _logger;

    public TopicController(ILogger<TopicController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Topics", Name = "GetTopics")]
    public string GetTopics()
    {
        return "paçoca";
    }
}
