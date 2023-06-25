
using DashboardLib.Dtos;
using DeveloperDashboardClient.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperDashboardClient.Pages
{
    public partial class Dashboard : ComponentBase
    {
        [Inject]
        public IDashboardServiceUI _dashboardService { get; set; }

        protected List<Repositories> dashboardVMs;
        protected List<Repositories> cacheAllData;

        List<Repositories> repos { get; set; }

        protected List<string> projects;
        public string selectedRepo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            cacheAllData = await _dashboardService.GetMasterProjectsFromAllTeams().ConfigureAwait(false);
            dashboardVMs = cacheAllData;
            //await GetAllProjects();
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

        public void BtnSearch_GetProjectDetails()
        {
            try
            {
                dashboardVMs = cacheAllData.Where(x => x.Name == selectedRepo).ToList();
                StateHasChanged();

                //var projects = await _dashboardService.FilterByProjects(selectedRepo).ConfigureAwait(false);
                //repos = projects.ToList();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public void BtnResetFilter_GetAllProjectDetails()
        {
            try
            {
                dashboardVMs = cacheAllData;
                StateHasChanged();

                //var projects = await _dashboardService.FilterByProjects(selectedRepo).ConfigureAwait(false);
                //repos = projects.ToList();
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
