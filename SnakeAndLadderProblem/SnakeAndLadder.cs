
using System;

namespace SnakeAndLadderProblem
{

    class Player {
        private int PlayerPosition;
        private int DiceRollCount = 0;

        public void SetPlayerPosition(int NextPosition)
        {
            PlayerPosition += NextPosition;
            if (PlayerPosition < 0)
                PlayerPosition = 0;
        }

        public Player(int StartPosition)
        {
            this.PlayerPosition = StartPosition;
        }

        public int GetDiceRollCount() {
            return DiceRollCount;
        }

        public void IncrementDiceRollCount() {
            DiceRollCount++;
        }

        public int GetPlayerPosition()
        {
            return PlayerPosition;
        }
    }
    class SnakeAndLadder
    {
        private const int StartPosition = 0;
        private int CurrentPlayer = 0;
        private const int WinningPosition = 100;
        private int IdlePlayer = 0;
        private Player[] player = new Player[2];       

        public enum PlayOption {
            NoPlay, Ladder, Snake
        }
        public SnakeAndLadder()
        {
            player[0] = new Player(StartPosition);
            player[1] = new Player(StartPosition);
        }
        
        public void ShowPosition()
        {
            for (int i = 0; i < player.Length; i++)
            {
                Console.WriteLine("Player "+ (i+1) +" position: " + player[i].GetPlayerPosition());
            }
        }
        private int GetDiceOutcome() {
            player[CurrentPlayer].IncrementDiceRollCount();
            return new Random().Next(1, 7);
        }

        public PlayOption GetPlayOption() {          
            return (PlayOption)new Random().Next(0, 3);            
        }

        public void MakeMove() {
            int NextPosition = GetDiceOutcome();
            Console.WriteLine("Dice rolled no.: "+ player[CurrentPlayer].GetDiceRollCount() +" outcome: "+ NextPosition);
            switch (GetPlayOption()) {
                case PlayOption.Ladder:
                    Console.WriteLine("Play option: Ladder");                     
                    NextPosition = player[CurrentPlayer].GetPlayerPosition() + NextPosition > WinningPosition ? 0 : NextPosition;
                    player[CurrentPlayer].SetPlayerPosition(NextPosition);
                    break;
                case PlayOption.Snake:                   
                    Console.WriteLine("Play option: Snake");
                    player[CurrentPlayer].SetPlayerPosition(~NextPosition);
                    ChangePlayer();
                    break;
                default:                    
                    Console.WriteLine("Play option: NO PLAY");
                    ChangePlayer();
                    break;
            }     
        }

        public void ChangePlayer() {
            int Temp = CurrentPlayer;
            CurrentPlayer = IdlePlayer;
            IdlePlayer = Temp;
        }
        public void Toss() {
            CurrentPlayer = new Random().Next(0, 2);
            if (CurrentPlayer == 0)
                IdlePlayer = 1;
        }

        public void PlayUntilWin()
        {
            Toss();
            ShowPosition();
            while (player[0].GetPlayerPosition() != WinningPosition && player[1].GetPlayerPosition() != WinningPosition)
            {
                Console.WriteLine("Player " + (CurrentPlayer + 1) + " is playing");
                MakeMove();
                ShowPosition();
                Console.WriteLine();
            }

            Console.WriteLine("Player "+ (CurrentPlayer + 1) +" won");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snake And Ladder Game");
            SnakeAndLadder snakeAndLadder = new SnakeAndLadder();

            snakeAndLadder.PlayUntilWin();

        }
    }
}
