using Microsoft.AspNetCore.Mvc;

public static class TopicEndpoints
{
    public static void MapTopicRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/topics", ([FromServices] LiteDbAgent agent) =>
        {
            return agent.GetAllTopics();
        });
      
    }
}