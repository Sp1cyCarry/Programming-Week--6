namespace ConsoleApp3;

class Program
{
    const string baseFile = "../../../ForrestGump.txt";
    
    static void Main(string[] args)
    {
        Program p = new Program();
        p.Start();
    }

    void Start()
    {
        try
        {
            Console.Write("Please enter a word: ");
            string input = Console.ReadLine();
            Console.WriteLine();
            int searchValue = SearchWordInFile(baseFile, input);
            Console.WriteLine($"\nNumber of lines which contain the word: {searchValue}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Unhandeled Error occured! Please try again!");
        }
    }

    public bool WordInLine(string line, string word)
    {
        if (line.Contains(word))
        {
            return true;
        }
        return false;
    }
    
    public int SearchWordInFile(string filename, string word)
    {
        int countOfWords = 0;
        using (StreamReader sr = new StreamReader(filename))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (WordInLine(line, word))
                {
                    Console.WriteLine(line);
                    countOfWords++;
                }
            }
        }
        return countOfWords;
    }
}