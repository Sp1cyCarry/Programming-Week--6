namespace ConsoleApp1;

class Program
{
    const string BaseFilePath = "../../../users";
    
    static void Main(string[] args)
    {
        Program p = new Program();
        p.Start();
    }

    void Start()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        string fileName = $"{BaseFilePath}/{name}.json";

        if (Person.IsSavedToFile(fileName))
        {
            Console.WriteLine($"Welcome back {name}");
            Person person = Person.ReadPersonFromFile(fileName);
            Console.WriteLine("We have the following info about you:");
            person.Display();
        }
        else
        {
            Person person = Person.ReadPerson(name);
            Person.WritePerson(person, fileName);
        }
    }
}