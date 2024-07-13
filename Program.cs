using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace guessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? choice = null;
            while (choice != "0")
            {

                Console.WriteLine("...Welcome to Guess where the fun definitly ends. How hard you want it?");
                Console.WriteLine(@"1. Easy, for dumb-dumbs that don't guess no good, and need 8 guesses... And I assume think that's correct grammar.
2. Meduim, For those that don't want to try too hard, but don't want to be treat like ""easy"" people; 6 guesses
3. Hard, ooo you think you can guess correctly in 4 guesses good for you.
4. Baby mode, you have no limit, just mash the keyboard into mush like your brain must be");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        GuessingGame(8,false);
                        break;
                    case "2":
                        GuessingGame(6, false);
                        break;
                    case "3":
                        GuessingGame(4, false);
                        break;
                    case "4":
                        GuessingGame(0, true);
                        break;

                }
            }

                void GuessingGame(int guesses, bool unlimited)
                {
                    Random random = new Random();
                    int secretNumber = random.Next(1, 101);
                    //int secretNumber = 42;
                    Console.WriteLine("Guess the NUMBER!!!");
                    Console.WriteLine("Enter a number between 1-100~");
                    int count = 0;
                    while (unlimited || count < guesses)
                    {
                        int guess;

                        if (int.TryParse(Console.ReadLine()?.Trim(), out guess))
                        {
                            Console.WriteLine($"You guessed... and... {(guess == secretNumber ? "Correct." : "ERRRRRR wrong, you suck.")}");

                            if (guess > secretNumber && count >= 2)
                            {
                                Console.WriteLine($"It's a smaller number than {guess}. Are you having problems, this isn't hard...");
                            }
                            else if (guess < secretNumber && count >= 2)
                            {
                                Console.WriteLine($"It's a larger number than {guess}. Still guessing??? Do better.");
                            }
                            else if (guess > secretNumber)
                            {
                                Console.WriteLine($"Try a smaller number than {guess}.");
                            }
                            else if (guess < secretNumber)
                            {
                                Console.WriteLine($"Try a larger number than {guess}.");
                            }
                            else
                            {
                                Console.WriteLine("Wooow, look at you, you guessed the number, so what do you want now? get out of here.");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry, try again. And this counts as a try... How hard is it to hit a number, like???");
                        }

                        count++;
                    Console.WriteLine($"You have {(unlimited ? "UNLIMITED guesses, cause you're scared of challenge!" : guesses - count)} guesses left");

                        if (count == guesses)
                        {
                            Console.WriteLine("GAME OVER BRO!");
                            return;
                        }
                    }
                }


        }
    }
}
