using DeveloperDashboardAPI.Dtos;
using DeveloperDashboardAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService, ILogger<DashboardController> logger)
        {
            _dashboardService = dashboardService;
            _logger = logger;
        }

        [HttpGet(Name = "alldata")]
        public async Task<ActionResult<IEnumerable<Repositories>>> GetAllData()
        {
            List<Repositories>? result = null;
            try
            {
                result = await CacheServices.GetCachedResponse<List<Repositories>>("GitResponse", _dashboardService.GetAllProjectsFromAllTeams);
                //var result = await _dashboardService.GetAllProjectsFromAllTeams().ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

            return Ok(result);
        }


        /// This is just a placeholder endpoint, update the code as per requirement
        /// https://localhost:7212/api/Dashboard/popupdata

        //[HttpGet(Name = "popupdata")]
        //public async Task<ActionResult<PopupData>> GetPopupData()
        //{
        //    List<PopupData>? result = null;
        //    try
        //    {
        //        var result = await _popupService.GetPopupData().ConfigureAwait(false);

        //        if (result == null)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        throw;
        //    }

        //    return Ok(result);
        //}
    }
}
