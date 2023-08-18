using System;


namespace MathGame.Games
{
    internal record GameResult(int Operand1, int Operand2, string Operation, int Result, int UserAnswer, bool IsCorrect);


    internal abstract class PlayableGame
    {
        protected const int MAX_NUM = 9;
        public abstract GameResult Play();

        protected virtual Tuple<int, int> GetRandomOperands()
        {
            var rand = new Random();
            return new Tuple<int, int>(rand.Next(1, MAX_NUM), rand.Next(1, MAX_NUM));

        }

        protected int GetAnswerFromUser()
        {
            bool isValid = false;
            var answer = Console.ReadLine();
            int result;
            do
            {
                isValid = int.TryParse(answer, out result);
                if (!isValid)
                {
                    Console.WriteLine("Error, bad input. Please enter in a number.");
                }
            } while (!isValid);
            return result;

        }
    }
}
