using DeveloperDashboard.DataServices;
using DeveloperDashboard.Dtos;
using Microsoft.AspNetCore.Components;

namespace DeveloperDashboard.Pages
{
    public partial class Albums : ComponentBase
    {
        [Inject]
        private IAlbumDataService albumDataService { get; set; }

        protected Album[] albums;

        protected override async Task OnInitializedAsync()
        {
            albums = await albumDataService.GetAllAlbums().ConfigureAwait(false);
        }
    }
}
