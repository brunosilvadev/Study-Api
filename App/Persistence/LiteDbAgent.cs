using LiteDB;

public class LiteDbAgent
{
    private const string connString = "Filename=Todo.db;mode=Exclusive";
    public List<Topic> GetAllTopics()
    {
        using (var db = new LiteDatabase(connString))
        {
            var topics = db.GetCollection<Topic>("topics");
            return topics.FindAll().ToList();
        }        
    }
    public int InsertTopic(Topic topic)
    {
        using (var db = new LiteDatabase(connString))
        {
            var topics = db.GetCollection<Topic>("topics");
            topics.Insert(topic);
            return topic.Id;
        }
    }
    public void DeleteTopic(int id)
    {
        using(var db = new LiteDatabase(connString))
        {
            var topics = db.GetCollection<Topic>("topics");
            topics.Delete(id);
        }
    }
    public void UpdateTopic(Topic topic)
    {
        if(topic.Id == 0)
        {
            throw new ArgumentException();
        }
        using (var db = new LiteDatabase(connString))
        {
            var topics = db.GetCollection<Topic>("topics");            
            topics.Update(topic);
        }
    }
}
