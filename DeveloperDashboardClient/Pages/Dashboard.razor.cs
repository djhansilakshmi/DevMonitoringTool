using DeveloperDashboardClient.DataServices;
using DeveloperDashboardClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace DeveloperDashboardClient.Pages
{
    public partial class Dashboard : ComponentBase
    {

        [Inject]
        public IDashboardService _dashboardService { get; set; }

        List<Repositories> dashboardVMs { get; set; }

        public async Task GetAllData()
        {

            try
            {
                var dash = await _dashboardService.GetAllProjectsFromAllTeams().ConfigureAwait(false);
                dashboardVMs = dash.ToList();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }
}
