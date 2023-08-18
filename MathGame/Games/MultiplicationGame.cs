using System;


namespace MathGame.Games
{
    internal class MultiplicationGame : PlayableGame
    {
        private const string OPERATION = "*";

   
        public override GameResult Play()
        {
            Console.WriteLine("You are now playing the multiplication game.");
            var (operand1, operand2) = GetRandomOperands();
            Console.WriteLine("What is the answer to the below maths equation");
            Console.WriteLine($"{operand1} * {operand2}");

            var userAnswer = GetAnswerFromUser();
            var result = operand1 * operand2;
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
