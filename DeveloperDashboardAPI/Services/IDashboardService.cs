﻿using DashboardLib.Dtos;

namespace DeveloperDashboardAPI.Services.DataServices
{
    public interface IDashboardService
    {
        Task<List<Repositories>> GetAllProjectsFromAllTeams();

        Task<List<Repositories>> GetAllRepos();
        Task<Repositories> GetRepo(string owner,string repoName);
        Task<List<Repositories>> GetMasterProjectsFromAllTeams();
        List<DashboardVM> FilterByTeamsNProjects(string Teams, string Project);
        List<DashboardVM> FilterByTeams(string Team);
        Task<List<Repositories>> FilterByProjects(string Project);

    }
}
