using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using DashboardLib.Dtos;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperDashboardClient.Pages
{
    public partial class RepoInfo : ComponentBase
    {


        private PieConfig _branchConfig;
        private PieConfig _prConfig;
        bool showValue = true;
        double codeCoveragevalue;
        GaugeTickPosition tickPosition;
        IEnumerable<GaugeTickPosition> tickPositions;

        [Parameter]
        public Repositories repo { get; set; }
        protected override async Task OnInitializedAsync()
        {
            tickPositions = Enum.GetValues(typeof(GaugeTickPosition)).Cast<GaugeTickPosition>();
            tickPosition = GaugeTickPosition.Inside;

            if (@repo.Branches[0].CodeCoverage.Data.Repository.Metrics[9].Items[0].Values.Edges.Count > 0)
            {
                codeCoveragevalue = @repo.Branches[0].CodeCoverage.Data.Repository.Metrics[9].Items[0].Values.Edges[0].Node.Value;
            }
            else
            { codeCoveragevalue = 0; }


            #region "Branch Config"
            _branchConfig = new PieConfig
            {
                Options = new PieOptions
                {
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Branch Details"
                    }
                }
            };

            foreach (string color in new[] { "Active Branch", "InActive Branch" })
            {
                _branchConfig.Data.Labels.Add(color);
            }
          
             
            PieDataset<int> dataset = new PieDataset<int>(new[] { repo.Branches.Count(), repo.Branches.Count() })
            {
                BackgroundColor = new[]
                {
                    ColorUtil.ColorHexString(13, 71, 167),
                    ColorUtil.ColorHexString(77, 190, 206)
                }
            };

            _branchConfig.Data.Datasets.Add(dataset);
            #endregion

            #region "PR Config"
            _prConfig = new PieConfig
            {
                Options = new PieOptions
                {
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Pull Request Details"
                    }
                }
            };

            foreach (string color in new[] { "Open PR's", "Closed PR's" })
            {
                _prConfig.Data.Labels.Add(color);
            }


            int openPRs = 0;
            int closedPRs = 0;
            if (repo.Branches[0].PullRequests is not null && repo.Branches[0].PullRequests.Count > 0)
            {
                foreach (var pullRequest in repo.Branches[0].PullRequests)
                {
                    if (pullRequest.State == "open")
                        openPRs++;
                    else
                        closedPRs++;
                }
            }

            PieDataset<int> data = new PieDataset<int>(new[] { openPRs, closedPRs })
            {
                BackgroundColor = new[]
                {
                    ColorUtil.ColorHexString(249, 176, 65),
                    ColorUtil.ColorHexString(91, 198, 35)
                }
            };

            _prConfig.Data.Datasets.Add(data);
            #endregion


            //await GetAllProjects();
        }
    }
}
