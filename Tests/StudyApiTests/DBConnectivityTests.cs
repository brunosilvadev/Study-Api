﻿using Xunit;

namespace StudyApiTests;

public class DBConnectivityTests
{
    [Fact]
    public void CheckCosmosDBConnects()
    {
        Assert.True(true);
    }
    [Fact]
    public void CheckLiteDbConnects()
    {
        LiteDbAgent agent = new LiteDbAgent();
        Assert.NotNull(agent.GetAllTopics());
    }   
}
