namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        p.Start();
    }

    void Start()
    {
        Hangman hangman = new Hangman();
        hangman.PlayGame();
    }
}