namespace DashboardLib.Dtos
{
    public class DashboardVM
    {
        public string Project { get; set; }
        public string BranchName { get; set; }
        public int TotalPR { get; set; }
        public double CodeCoverage { get; set; }
        public DateTime LastDeployed { get; set; }
        public BuildStatus BuildStatus { get; set; }
    }

    public enum BuildStatus
    {
        Failed = 0,
        Success = 1,
        InProgress = 2
    }
}
