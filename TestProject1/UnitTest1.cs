using DepthChartConsole;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestDepthChart()
        {
            DepthChart depthChart = new DepthChart();
            var BlaineGabbert = new Player { number = 11, name = "Blaine Gabbert", position = "QB" };
            var TomBrady = new Player { number = 12, name = "Tom Brady", position = "QB" };
            var KyleTrask = new Player { number = 2, name = "Kyle Trask",position = "QB" };

            var MikeEvans = new Player { number = 13, name = "Mike Evans", position = "LWR" };
            var JaelonDarden = new Player { number = 1, name = "Jaelon Darden" };
            var ScottMiller = new Player { number = 10, name = "Scott Miller" };

            depthChart.AddPlayerToDepthChart("QB", TomBrady, "0");
            depthChart.AddPlayerToDepthChart("QB", BlaineGabbert, "1");
            depthChart.AddPlayerToDepthChart("QB", KyleTrask, "2");

            depthChart.AddPlayerToDepthChart("LWR", MikeEvans, "0");
            depthChart.AddPlayerToDepthChart("LWR", JaelonDarden, "1");
            depthChart.AddPlayerToDepthChart("LWR", ScottMiller, "2");

            var backups = depthChart.GetBackups("QB", TomBrady);
            
            backups = depthChart.GetBackups("QB", JaelonDarden);

            backups = depthChart.GetBackups("QB", MikeEvans);

            backups = depthChart.GetBackups("QB", BlaineGabbert);

            var fullDepthChart = depthChart.GetFullDepthChart();
            var removedPlayer = depthChart.RemovePlayerFromDepthChart("LWR", MikeEvans);
            fullDepthChart = depthChart.GetFullDepthChart();
        }
    }
}
