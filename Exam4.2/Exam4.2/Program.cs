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

            #region
            GameSystem game = new GameSystem();
            game.UpdatePoints("player1", 100);
            game.UpdatePoints("player2", 150);
            game.UpdatePoints("player3", 75);
            game.UpdatePoints("player4", 200);

            Player[] sortedPlayers = game.GetPlayersSortedByPoints();
            foreach (Player player in sortedPlayers)
            {
                Console.WriteLine($"Player {player.Id}: {player.Points} points");
            }
            #endregion
        }
    }

    #region
    //Element
    class Player
    {
        public string Id { get; set; }
        public int Points { get; set; }

        public Player(string id, int points)
        {
            Id = id;
            Points = points;
        }
    }

    class GameSystem
    {
        private Player[] players;
        private int count;

        public GameSystem()
        {
            players = new Player[10]; // Definer størrelsen af arrayet efter behov
            count = 0;
        }

        public void UpdatePoints(string playerId, int points)
        {
            // Find spilleren i arrayet eller indsæt den på den korrekte position
            int index = FindPlayerIndex(playerId);
            if (index != -1)
            {
                players[index].Points = points;
            }
            else
            {
                InsertPlayer(playerId, points);
            }
        }

        private int FindPlayerIndex(string playerId)
        {
            for (int i = 0; i < count; i++)
            {
                if (players[i].Id == playerId)
                {
                    return i;
                }
            }
            return -1;
        }

        private void InsertPlayer(string playerId, int points)
        {
            // Find den rigtige position til indsættelse baseret på point
            int insertIndex = 0;
            while (insertIndex < count && points < players[insertIndex].Points)
            {
                insertIndex++;
            }

            // Flyt eksisterende spillere for at gøre plads til den nye spiller
            for (int i = count - 1; i >= insertIndex; i--)
            {
                players[i + 1] = players[i];
            }

            // Indsæt den nye spiller
            players[insertIndex] = new Player(playerId, points);
            count++;
        }

        public Player[] GetPlayersSortedByPoints()
        {
            Player[] sortedPlayers = new Player[count];
            Array.Copy(players, sortedPlayers, count);
            Array.Sort(sortedPlayers, (p1, p2) => p2.Points.CompareTo(p1.Points));
            return sortedPlayers;
        }

    }
    #endregion
}




