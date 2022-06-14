using Xunit;

namespace StudyApiTests;

public class LiteDbCrud
{
    [Fact]
    public void InsertTestTopic()
    {
        LiteDbAgent agent = new LiteDbAgent();
        Assert.IsType<int>(agent.InsertTopic(new Topic() { Name = TestHelper.RandomString(5) }));
    }
}
