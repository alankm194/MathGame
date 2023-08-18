using MathGame.Games;


namespace MathGame
{
    internal class Game
    {
        public List<GameResult> GameHistory { get; private set; }

        public Game() { 
            this.GameHistory = new List<GameResult>(); 
        }
        public void StartGame()
        {
            Console.WriteLine("Hello Please enter in your name");
            var name = Console.ReadLine();

            PrintOptions(name ?? "Player");
            SelectOption();

        }
        private void PrintOptions (string name)
        {
            Console.WriteLine($"Hello {name}, Please selection an option to play a game or look through your game history.");
            Console.WriteLine("""
                Option 1: Play the addition game
                Option 2: Play the subtraction game
                Option 3: Play the multiplication game
                Option 4: Play the division game
                Option 5: Print game history
                Option 6: Exit game
                """);
        }

        private void PrintHistory()
        {
            if (GameHistory.Count == 0) {
                Console.WriteLine("Empty History");
                return;
            }
            for (int i = 0; i < GameHistory.Count; i++) 
            {
                var operand1 = GameHistory[i].Operand1;
                var operand2 = GameHistory[i].Operand2;
                var operation = GameHistory[i].Operation; 
                var result = GameHistory[i].Result;
                var userAnswer = GameHistory[i].UserAnswer;
                Console.WriteLine($"{i + 1}: {operand1} {operation} {operand2} = {result} : your answer was {userAnswer}");
            }
        }
        private void SelectOption()
        {
            Console.WriteLine("Please select a option");
            while (true)
            {
                string? gameSelected = Console.ReadLine();
                GameResult? gameResult = null;
                switch (gameSelected)
                {
                    case "1":
                        gameResult = new AdditionGame().Play();
                        break;
                    case "2":
                        gameResult = new SubtractionGame().Play();
                        break;
                    case "3":
                        gameResult = new MultiplicationGame().Play();
                        break;
                    case "4":
                        gameResult = new DivisionGame().Play();
                        break;
                    case "5":
                        PrintHistory();
                        break;
                    case "6":
                        Console.WriteLine("Exiting game. Thank you for playing");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error Selecting Option, Please Choose again");
                        break;
                }
                if (gameResult != null)
                {
                    GameHistory.Add(gameResult);
                }
                Console.WriteLine("Please select another option");
            }
        }

    }
}
