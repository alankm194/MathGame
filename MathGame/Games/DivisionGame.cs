using MathGame.Games;
using System;

namespace MathGame.Games
{
    internal class DivisionGame : PlayableGame 
    {
        private const int MAX_DIVISOR = 99;

        private const string OPERATION = "/";
        protected override Tuple<int, int> GetRandomOperands()
        {
            var rand = new Random();
            int op1;
            int op2;
            do
            {
                op1 = rand.Next(0, MAX_DIVISOR);
                op2 = rand.Next(1, MAX_DIVISOR);
            } while (op1 % op2 != 0);

            return new Tuple<int, int> (op1, op2);
        }

        public override GameResult Play()
        {
            Console.WriteLine("You are now playing the division game.");
            var (operand1, operand2) = GetRandomOperands();
            Console.WriteLine("What is the answer to the below maths equation");
            Console.WriteLine($"{operand1} / {operand2}");

            var userAnswer = GetAnswerFromUser();
            var result = operand1 / operand2;
            if (result == userAnswer)
            {
                Console.WriteLine("you are correct");
            }
            else
            {
                Console.WriteLine("you are incorrect");
            }
            return new GameResult(operand1, operand2, OPERATION, result, userAnswer, result == userAnswer);
        }
    }
}
