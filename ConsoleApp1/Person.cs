using System.Text.Json;

namespace ConsoleApp1;

public class Person
{
        public Person(string name, string city, int age)
        {
            Name = name;
            City = city;
            Age = age;
        }

        public string Name { get; }
        public string City { get; }
        public int Age { get; }

        public override string ToString()
        {
            string output = $"Name: {Name}\n";
            output += $"City: {City}\n";
            output += $"Age: {Age}\n";
            return output;
        }

        public void Display()
        {
            Console.WriteLine(this);
        }

        public static Person ReadPerson(string name)
        {
            Console.Write("Enter your city: ");
            string city = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            return new Person(name, city, age);
        }

        public static Person ReadPersonFromFile(string filename)
        {
            using (StreamReader streamReader = new StreamReader(filename))
            {
                string json = streamReader.ReadLine();
                return JsonSerializer.Deserialize<Person>(json);
                //string name = streamReader.ReadLine();
                //string city = streamReader.ReadLine();
                //int age = int.Parse(streamReader.ReadLine());
                //return new Person(name, city, age);
            }
        }

        public static void WritePerson(Person p, string filename)
        {
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                string json = JsonSerializer.Serialize(p);
                streamWriter.WriteLine(json);
                //streamWriter.WriteLine(p.Name);
                //streamWriter.WriteLine(p.City);
                //streamWriter.WriteLine(p.Age);
            }
            Console.WriteLine("User written to file");
        }

        public static bool IsSavedToFile(string filename)
        {
            return File.Exists(filename);
        }
}