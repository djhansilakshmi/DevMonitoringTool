namespace DashboardLib.Dtos
{
    public class Data
    {
          public RepositoryDetails Repository { get; set; }
            //public ViewerDetails viewer { get; set; }
    }

    public class Edge
    {
        public Node Node { get; set; }
       // public string cursor { get; set; }
    }

    public class Item
    {
         public string Id { get; set; }
        //public string key { get; set; }
        //public object threshold { get; set; }
        //public double? latestValue { get; set; }
        //public string latestValueDisplay { get; set; }
        //public object thresholdStatus { get; set; }
        public Values Values { get; set; }
    }

    public class Metric
    {
         public string Name { get; set; }
        //public string description { get; set; }
        //public string positiveDirection { get; set; }
        //public string unit { get; set; }
        //public int minValueAllowed { get; set; }
        //public int? maxValueAllowed { get; set; }
        //public bool isThresholdEnforced { get; set; }
        //public bool isReported { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Node
    {
        //public string id { get; set; }
        public double Value { get; set; }
        public string ValueDisplay { get; set; }
        public object Threshold { get; set; }
        public object ThresholdStatus { get; set; }
       // public string commitOid { get; set; }
        //public DateTime createdAt { get; set; }
    }

    public class PageInfo
    {
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public string StartCursor { get; set; }
        public string EndCursor { get; set; }
    }

    public class RepositoryDetails
    {
        //public string name { get; set; }
        //public string id { get; set; }        
        public List<Metric> Metrics { get; set; }
    }

    public class ViewerDetails
    {
        public string Email { get; set; }
    }

    public class CodeCoverage
    {
        public Data Data { get; set; }
    }

    public class Values
    {
       // public PageInfo pageInfo { get; set; }
        public List<Edge> Edges { get; set; }
       // public int totalCount { get; set; }
    }
}
