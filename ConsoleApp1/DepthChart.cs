using System;
using System.Collections.Generic;
using System.Linq;

namespace DepthChartConsole
{
    public class DepthChart
    {
        Dictionary<string, List<Player>> depthChart = new Dictionary<string, List<Player>>();
        public DepthChart()
        {
            InitializeDepthChart();
        }
        public Dictionary<string, List<Player>> AddPlayerToDepthChart(string position, Player player, string position_depth)
        {
            
            if (!string.IsNullOrWhiteSpace(position_depth))
            {
                depthChart[position].Insert(Convert.ToInt32(position_depth), player);
            }

            if (string.IsNullOrWhiteSpace(position_depth))
            {
                depthChart[position].Add(player);
            }

            ReorderPlayers(position);

            return depthChart;
        }

        public void ReorderPlayers(string position)
        {
            depthChart[position].OrderByDescending(x => x.number);
        }

        public Player RemovePlayerFromDepthChart(string position, Player player)
        {
            if (!string.IsNullOrWhiteSpace(position) && player != null)
            {
                if (depthChart[position].Contains(player))
                {
                    depthChart[position].Remove(player);
                    ReorderPlayers(position);
                    return player;
                }
            }
            ReorderPlayers(position);
            return null;
        }

        public List<Player> GetBackups(string position, Player player)
        {
            var backupPlayers = new List<Player>();
            if (!string.IsNullOrWhiteSpace(position) && player != null)
            {
                ReorderPlayers(position);
                if (depthChart[position].Contains(player))
                {
                    backupPlayers = depthChart[position].Where(x => x.number < player.number).ToList().OrderByDescending(x => x.number).ToList();
                    return backupPlayers;
                }
            }
            return backupPlayers;
        }

        public Dictionary<string, List<Player>> GetFullDepthChart()
        {
            var result = new Dictionary<string, List<Player>>();
            foreach (var key in depthChart.Keys)
            {
                var dcList = depthChart[key];
                List<Player> playersList = new List<Player>();
                foreach(var player in dcList)
                {
                    playersList.Add(new Player { number = player.number, name = player.name });
                }
                result.Add(key, playersList);
            }
            return result;
        }

        public void InitializeDepthChart()
        {
            depthChart.Add("QB", new List<Player>());
            depthChart.Add("LWR", new List<Player>());
        }
    }

    public class Player
    {
        public int number { get; set; }
        public string name { get; set; }
        public string position { get; set; }
    }
}
