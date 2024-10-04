namespace btl_backend.Models;

public class Problem
{
    public string? ProblemID { get; set; }

    public string? ProblemName { get; set; }

    public string? ProblemContent { get; set; }

    public Topic? ProblemTopics { get; set; }

    public List<string>? ProlemTestCode { get; set; }

    public TestCase? ProblemTestCases { get; set; }
}

public class Topic
{
    public List<TopicDetail>? TopicsDetails { get; set; }
}

public class TopicDetail
{
    public string? TopicID { get; set; }

    public string? TopicName { get; set; }

    public string? TopicContent { get; set; }
}

public class TestCase
{
    public List<TestCaseDetail>? TestCaseDetails { get; set; }
}

public class TestCaseDetail
{
    public string? TestCaseID { get; set; }

    public string? Input { get; set; }

    public string? Output { get; set; }

}