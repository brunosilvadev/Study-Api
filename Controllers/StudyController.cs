using Microsoft.AspNetCore.Mvc;

namespace Study_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudyController : ControllerBase
{
    private readonly ILogger<StudyController> _logger;

    public StudyController(ILogger<StudyController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Topics", Name = "GetTopics")]
    public string GetTopics()
    {
        return "paçoca";
    }
}
