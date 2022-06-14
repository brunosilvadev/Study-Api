using LiteDB;

public class LiteDbAgent
{
    public List<Topic> GetAllTopics()
    {
        using (var db = new LiteDatabase(@"database.db"))
        {
            var topics = db.GetCollection<Topic>("topics");
            return topics.Query().OrderBy(t => t.Name).ToList();
        }        
    }
    public int InsertTopic(Topic topic)
    {
        using (var db = new LiteDatabase(@"database.db"))
        {
            var topics = db.GetCollection<Topic>("topics");
            topics.Insert(topic);
            return topic.Id;
        }
    }

    public void DeleteTopic(int id)
    {
        using(var db = new LiteDatabase(@"database.db"))
        {
            var topics = db.GetCollection<Topic>("topics");
            topics.Delete(id);
        }
    }
}
