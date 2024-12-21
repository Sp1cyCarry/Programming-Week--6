namespace ConsoleApp2;

public class Hangman
{
    const string filePath = "../../../words.txt";
    const int NumberOfGuessesAllowed = 7;
    private List<string> Words = new List<string>();

    public Hangman()
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();
                if (word.Length > 1)
                {
                    Words.Add(word);
                }
            }
        }
    }

    public void PlayGame()
    {
        Random random = new Random();
        string word = Words[random.Next(0,Words.Count)];

        //Console.WriteLine(word);
        
        int numberOfGuesses = 0;
        
        bool hasWon = false;
        
        List<char> lettersGuessed = new List<char>();
        
        try
        {
            while (!hasWon && numberOfGuesses < NumberOfGuessesAllowed)
            {
                if (lettersGuessed.Count > 0)
                {
                    foreach (char letter in lettersGuessed)
                    {
                        Console.Write($"{letter} ");
                    }

                    Console.WriteLine();
                }

                foreach (char c in word)
                {
                    if (lettersGuessed.Contains(c))
                    {
                        Console.Write(c);
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
                Console.Write("\nGuess a letter: ");

                char letterGuessed = Console.ReadLine()[0];

                if (lettersGuessed.Contains(letterGuessed))
                {
                    throw new Exception($"Letter already guessed: {letterGuessed}");
                }

                lettersGuessed.Add(letterGuessed);
                if (!word.Contains(letterGuessed))
                {
                    numberOfGuesses++;
                }
                hasWon = true;
                foreach (char c in word)
                {
                    if (!lettersGuessed.Contains(c))
                    {
                        hasWon = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("*********");
            Console.WriteLine(ex.Message);
            Console.WriteLine("*********");
            Console.WriteLine();
        }
        
        if (hasWon)
        {
            Console.WriteLine("you won");
        }
        else
        {
            Console.WriteLine("you lost");
        }

        Console.Write($"The word was: {word}");
    }
}