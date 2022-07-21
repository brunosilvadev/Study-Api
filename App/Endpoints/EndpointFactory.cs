public static class EndpointFactory
{
    public static void RegisterEndpoint(this IEndpointRouteBuilder app)
    {
        TopicEndpoint topic = new(app.ServiceProvider.GetService<LiteDbAgent>() ?? throw new ArgumentNullException(nameof(LiteDbAgent) + " not configured"));
        topic.RegisterRoutes(app);
    }
}
