using System;

namespace SnakeAndLadderProblem
{
    class SnakeAndLadder
    {
        private const int StartPosition = 0;
        private int PlayerPostion;

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

        public void RollTheDice()
        {
            Console.WriteLine("Dice rolled: " +GetDiceNumber());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snake And Ladder Game");
            SnakeAndLadder snakeAndLadder = new SnakeAndLadder();
            snakeAndLadder.ShowPosition();
            snakeAndLadder.RollTheDice();
        }
    }
}
