namespace DeveloperDashboardClient.Dtos
{
    public class Data
    {
          public RepositoryDetails repository { get; set; }
            //public ViewerDetails viewer { get; set; }
    }

    public class Edge
    {
        public Node node { get; set; }
       // public string cursor { get; set; }
    }

    public class Item
    {
         public string id { get; set; }
        //public string key { get; set; }
        //public object threshold { get; set; }
        //public double? latestValue { get; set; }
        //public string latestValueDisplay { get; set; }
        //public object thresholdStatus { get; set; }
        public Values values { get; set; }
    }

    public class Metric
    {
         public string name { get; set; }
        //public string description { get; set; }
        //public string positiveDirection { get; set; }
        //public string unit { get; set; }
        //public int minValueAllowed { get; set; }
        //public int? maxValueAllowed { get; set; }
        //public bool isThresholdEnforced { get; set; }
        //public bool isReported { get; set; }
        public List<Item> items { get; set; }
    }

    public class Node
    {
        //public string id { get; set; }
        public double value { get; set; }
        public string valueDisplay { get; set; }
        public object threshold { get; set; }
        public object thresholdStatus { get; set; }
       // public string commitOid { get; set; }
        //public DateTime createdAt { get; set; }
    }

    public class PageInfo
    {
        public bool hasNextPage { get; set; }
        public bool hasPreviousPage { get; set; }
        public string startCursor { get; set; }
        public string endCursor { get; set; }
    }

    public class RepositoryDetails
    {
        //public string name { get; set; }
        //public string id { get; set; }        
        public List<Metric> metrics { get; set; }
    }


    public class ViewerDetails
    {
        public string email { get; set; }
       
    }

    public class CodeCoverage
    {
        public Data data { get; set; }
    }

    public class Values
    {
       // public PageInfo pageInfo { get; set; }
        public List<Edge> edges { get; set; }
       // public int totalCount { get; set; }
    }

}
