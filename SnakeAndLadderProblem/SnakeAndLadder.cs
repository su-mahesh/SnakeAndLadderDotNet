using System;

namespace SnakeAndLadderProblem
{
    class SnakeAndLadder
    {
        private const int StartPosition = 0;
        private int PlayerPosition;
        private const int WinningPosition = 100;
        private int NoOfDiceRoll = 0;

        public enum PlayOption {
            No_Play, Ladder, Snake
        }
        public SnakeAndLadder()
        {
            PlayerPosition = StartPosition;
        }

        public void ShowPosition()
        {
            Console.WriteLine("Player position: "+PlayerPosition);
        }
        private int GetDiceNumber() {
            NoOfDiceRoll++;
            return new Random().Next(1, 7);
        }

        public PlayOption GetPlayOption() {
           
            return (PlayOption)new Random().Next(0, 3);            
        }

        public void MakeMove() {
            int NextPosition = GetDiceNumber();
            Console.WriteLine("Dice rolled no.: "+ NoOfDiceRoll +" outcome: "+ NextPosition);
            switch (GetPlayOption()) {
                case PlayOption.Ladder:
                    Console.WriteLine("Play option: Ladder");
                    PlayerPosition = PlayerPosition + NextPosition > WinningPosition ? PlayerPosition : PlayerPosition + NextPosition;
                    break;
                case PlayOption.Snake:
                    Console.WriteLine("Play option: Snake");
                    PlayerPosition -= NextPosition;
                    if (PlayerPosition < 0)
                        PlayerPosition = 0;
                    break;
                default:
                    Console.WriteLine("Play option: NO PLAY");
                    break;
            }
        }

        public void PlayUntilWin()
        {
            ShowPosition();
            while (PlayerPosition != WinningPosition)
            {
                MakeMove();
                ShowPosition();
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snake And Ladder Game");
            SnakeAndLadder snakeAndLadder = new SnakeAndLadder();

            snakeAndLadder.PlayUntilWin();

        }
    }
}
