using LiteDB;
public class Topic
{
    [BsonId]
    public int Id {get;set;}
    public string Name { get; set; } = default!;
    public int Progress { set; get; }
}