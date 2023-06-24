using DeveloperDashboardAPI.Dtos;

namespace DeveloperDashboardAPI.Services
{
    public interface IDashboardService
    {
        Task<List<Repositories>> GetAllProjectsFromAllTeams();
        List<DashboardVM> FilterByTeamsNProjects(string Teams, string Project);
        List<DashboardVM> FilterByTeams(string Team);
        List<DashboardVM> FilterByProjects(string Project);
    }
}
