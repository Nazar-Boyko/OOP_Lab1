using System;

namespace laba1
{

    class Game
    {
        public string OpponentName;
        public int Rating;
        public string GameStatus;
        public int GameCount;
        public Game(string opponentName, int rating, string gameStatus, int gameCount)
        {
            OpponentName = opponentName;
            Rating = rating;
            GameStatus = gameStatus;
            GameCount = gameCount;
        }
    }

    class GameAccount
    {
        public string UserName { get; private set; }
        public int CurrentRating { get; private set; }
        public int GamesCount { get { return GameHistory.Count; } }
        private List<Game> GameHistory = new List<Game>();

        public GameAccount(string UserName, int initialRating)
        {
            if (initialRating < 1)
            {
                throw new ArgumentException("Initial rating cannot be less than 1.");
            }

            this.UserName = UserName;
            CurrentRating = initialRating;
        }

        public void WinGame(string opponentName, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating for the game cannot be negative.");
            }

            CurrentRating += rating;
            GameHistory.Add(new Game(opponentName, rating, "Win", GamesCount));
        }

        public void LoseGame(string opponentName, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating for the game cannot be negative.");
            }

            CurrentRating -= rating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GameHistory.Add(new Game(opponentName, rating, "Lose", GamesCount));
        }

        public void GetStats()
        {
            Console.WriteLine($"Game history for {UserName}:");
            Console.WriteLine("Opponent     Status    Rating    Game Count");
            for(int i = 0; i < GamesCount; i++)
            {
                Console.WriteLine($"{GameHistory[i].OpponentName,-12} {GameHistory[i].GameStatus,-9} {GameHistory[i].Rating,-9} {i+1}");
            }
            Console.WriteLine("\n");
        }
    }

    internal class Program
    {
        static void Main()
        {
            GameAccount player1 = new GameAccount("Cody", 100);
            GameAccount player2 = new GameAccount("Casper", 110);
            GameAccount player3 = new GameAccount("John", 120);
            

            player1.WinGame(player2.UserName, 50);
            player2.LoseGame(player1.UserName, 35);
            player2.WinGame(player3.UserName, 40);
            player1.LoseGame(player2.UserName, 30);
            player1.WinGame(player2.UserName, 20);
            player2.LoseGame(player1.UserName, 20);
            player3.LoseGame(player2.UserName, 20);
            player2.LoseGame(player1.UserName, 60);

            player1.GetStats();
            player2.GetStats();
            player3.GetStats();
        }
    }

}