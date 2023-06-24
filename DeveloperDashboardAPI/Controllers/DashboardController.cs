using DashboardLib.Dtos;
using DeveloperDashboardAPI.Services.DataServices;
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

        [HttpGet("alldata")]
        public async Task<ActionResult<IEnumerable<Repositories>>> GetAllData()
        {
            List<Repositories>? gitResponse = null;
            try
            {
                //result = await CacheServices.GetCachedResponse<List<Repositories>>("GitResponse", _dashboardService.GetAllProjectsFromAllTeams);
                //var result = await _dashboardService.GetAllProjectsFromAllTeams().ConfigureAwait(false);

                gitResponse = await _dashboardService.GetMasterProjectsFromAllTeams().ConfigureAwait(false);

                if (gitResponse == null)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

            return Ok(gitResponse);
        }

        //[HttpGet("{repoName:length(20)}", Name = "GetRepo")]
        //public async Task<ActionResult<IEnumerable<Repositories>>> FilterByProjects(string repoName)
        //{
        //    List<Repositories>? gitResponse = null;
        //    try
        //    {
        //        gitResponse = await _dashboardService.FilterByProjects(repoName).ConfigureAwait(false);
              
        //        if (gitResponse == null)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        throw;
        //    }

        //    return Ok(gitResponse);
        //}

        //[HttpGet(Name = "GetAllMaster")]
        //public async Task<ActionResult<IEnumerable<Repositories>>> GetAllMasterData()
        //{
        //    List<Repositories>? gitResponse = null;
        //    try
        //    {

        //        gitResponse = await _dashboardService.GetMasterProjectsFromAllTeams().ConfigureAwait(false);


        //        if (gitResponse == null)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        throw;
        //    }

        //    return Ok(gitResponse);
        //}


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
