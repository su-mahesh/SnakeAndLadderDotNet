using System;

namespace SnakeAndLadderProblem
{
    class SnakeAndLadder
    {
        private const int StartPosition = 0;
        private int PlayerPostion;
        private const int WinningPosition = 100;

        public enum PlayOption {
            No_Play, Ladder, Snake
        }
        public SnakeAndLadder()
        {
            PlayerPostion = StartPosition;
        }

        public void ShowPosition()
        {
            Console.WriteLine("Player position: "+PlayerPostion);
        }
        private int GetDiceNumber() {
            return new Random().Next(1, 7);
        }

        public PlayOption GetPlayOption() {
           
            return (PlayOption)new Random().Next(0, 3);            
        }

        public void MakeMove() {
            int NextPosition = GetDiceNumber();
            Console.WriteLine("Dice rolled: "+ NextPosition);
            switch (GetPlayOption()) {
                case PlayOption.Ladder:
                    Console.WriteLine("Play option: Ladder");
                    PlayerPostion += NextPosition;
                    break;
                case PlayOption.Snake:
                    Console.WriteLine("Play option: Snake");
                    PlayerPostion -= NextPosition;
                    if (PlayerPostion < 0)
                        PlayerPostion = 0;
                    break;
                default:
                    Console.WriteLine("Play option: NO PLAY");
                    break;
            }
        }

        public void PlayUntilWin()
        {
            ShowPosition();
            while (PlayerPostion != WinningPosition)
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
