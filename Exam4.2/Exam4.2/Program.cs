using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Exam4._2
{
    // Eksempelbrug:
    class Program
    {
        static void Main()
        {
            GameSystem game = new GameSystem();
            game.UpdatePoints("player1", 100);
            game.UpdatePoints("player2", 150);
            game.UpdatePoints("player3", 75);
            game.UpdatePoints("player4", 200);

            List<Player> sortedPlayers = game.GetPlayersSortedByPoints();
            foreach (Player player in sortedPlayers)
            {
                Console.WriteLine($"Player {player.PlayerName}: {player.Points} points");
            }


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Stop();


            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
            ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }

    // Bucket
    class Player : IComparable<Player>
    {
        public string PlayerName { get; set; }
        public int Points { get; set; }

        public int CompareTo(Player other)
        {
            return other.Points.CompareTo(this.Points);
        }
    }

    class GameSystem
    {
        private Dictionary<string, Player> playerDict;
        private SortedSet<Player> playerSet;

        public GameSystem()
        {
            playerDict = new Dictionary<string, Player>();
            playerSet = new SortedSet<Player>();
        }

        public void UpdatePoints(string playerId, int points)
        {
            if (playerDict.ContainsKey(playerId))
            {
                Player player = playerDict[playerId];
                player.Points = points;
            }
            else
            {
                Player player = new Player { PlayerName = playerId, Points = points };
                playerDict[playerId] = player;
                playerSet.Add(player);
            }
        }

        public List<Player> GetPlayersSortedByPoints()
        {
            return new List<Player>(playerSet);
        }
    }

}
