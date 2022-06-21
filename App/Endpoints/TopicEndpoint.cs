using Microsoft.AspNetCore.Mvc;

public class TopicEndpoint : IEndpoint
{
    private LiteDbAgent _agent;
    public TopicEndpoint([FromServices] LiteDbAgent agent)
    {
        _agent = agent;
    }
    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("AllTopics", GetAllTopics);

        app.MapPost("InsertTopic", InsertTopic);

        app.MapDelete("DeleteTopic", DeleteTopic);

        app.MapPut("UpdateTopic", UpdateTopic);
    }

    private List<Topic> GetAllTopics()
    {
        return _agent.GetAllTopics();
    }
    private int InsertTopic(Topic topic)
    {
        return _agent.InsertTopic(topic);
    }
    private void DeleteTopic(int id)
    {
        _agent.DeleteTopic(id);
    }
    private void UpdateTopic(Topic topic)
    {
        if (topic == null)
        {
            throw new ArgumentNullException(nameof(topic));
        }
        _agent.UpdateTopic(topic);
    }    
}