
using DashboardLib.Dtos;
using DeveloperDashboardClient.Services;
using Microsoft.AspNetCore.Components;

namespace DeveloperDashboardClient.Pages
{
    public partial class Dashboard : ComponentBase
    {
        [Inject]
        public IDashboardServiceUI _dashboardService { get; set; }

        List<Repositories> dashboardVMs { get; set; }
        List<Repositories> repos { get; set; } 

        public string selectedRepo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetAllProjects();
        }

        public async Task GetAllProjects()
        {
            try
            {
                var projects = await _dashboardService.GetAllRepos().ConfigureAwait(false);
                repos = projects.ToList();
            }
            catch (Exception)
            {
               // throw;
            }
        }

        public async Task GetProjectDetails()
        {
            try
            {
                var projects = await _dashboardService.FilterByProjects(selectedRepo).ConfigureAwait(false);
                repos = projects.ToList();
            }
            catch (Exception)
            {

                //throw;
            }
        }



        public async Task GetAllData()
        {
            try
            {
                var gitResponse = await _dashboardService.GetMasterProjectsFromAllTeams().ConfigureAwait(false);

                dashboardVMs = gitResponse.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
