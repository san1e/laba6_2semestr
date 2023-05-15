using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;


namespace laba6_2semestr
{
    [XmlRoot("ZodiakData")]
    public struct Zodiak : IComparable<Zodiak>
    {
        [XmlElement("FirstName")]
        public string FirstName;
        [XmlElement("LastName")]
        public string LastName;
        [XmlElement("FZodiakSign")]
        public string ZodiakSign;
        [XmlIgnore]
        public int[] DateOfBirth;
        [XmlElement("Date")]
        public string Date;

        public Zodiak(string FirstName, string LastName, string ZodiakSign, string DateOfBirth,string Date)
        {
            FirstName = FirstName;
            LastName = LastName;
            ZodiakSign = ZodiakSign;
            DateOfBirth = DateOfBirth;
            Date = string.Join(".", DateOfBirth);
        }
        public int CompareTo(Zodiak obj)
        {
            int result = this.DateOfBirth[2].CompareTo(obj.DateOfBirth[2]);
            if (result == 0)
            {
                result = this.DateOfBirth[1].CompareTo(obj.DateOfBirth[1]);
                if (result == 0)
                {
                    result = this.DateOfBirth[0].CompareTo(obj.DateOfBirth[0]);
                }
            }
            return result;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть кiлькiсть людей: ");
            int n = int.Parse(Console.ReadLine());
            Zodiak[] people = new Zodiak[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Людина №{i + 1}");
                Console.Write("iм'я: ");
                people[i].FirstName = Console.ReadLine();
                Console.Write("Прiзвище: ");
                people[i].LastName = Console.ReadLine();
                Console.Write("Знак зодiаку: ");
                people[i].ZodiakSign = Console.ReadLine();
                Console.Write("Дата народження (у форматi ДД.ММ.РРРР): ");
                people[i].DateOfBirth = Console.ReadLine().Split('.').Select(int.Parse).ToArray();
                people[i].Date = string.Join(".", people[i].DateOfBirth);

            }
            Console.Clear();

            Array.Sort(people);

            string path = "Zodiak.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Zodiak peop in people)
                {
                    writer.WriteLine($"{peop.FirstName} {peop.LastName} ({peop.ZodiakSign}), {peop.DateOfBirth[0]:D2}.{peop.DateOfBirth[1]:D2}.{peop.DateOfBirth[2]}");
                }
            }

            string path1 = "Zodiak.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Zodiak[]), new XmlRootAttribute("ZodiakData"));

            using (TextWriter writer = new StreamWriter(path1))
            {
                serializer.Serialize(writer, people);
            }

            string[] lines = File.ReadAllLines("Zodiak.txt");

            Console.Write("Введiть прiзвище: ");
            string surname = Console.ReadLine();

            bool found = false;

            foreach (string line in lines)
            {
                string[] data = line.Split(' ');

                if (data[1] == surname)
                {
                    Console.WriteLine(line);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Людина з прiзвищем {surname} не знайдена");
            }


           
            using (FileStream fileStream = new FileStream(path1, FileMode.Open))
            {
                people = (Zodiak[])serializer.Deserialize(fileStream);
            }
            Console.WriteLine();
            Console.Write("Введiть прiзвище: ");
            surname = Console.ReadLine();

            found = false;
            foreach (Zodiak person in people)
            {
                if (person.LastName == surname)
                {
                    Console.WriteLine($"Iм'я i Фамiлiя: {person.FirstName} {person.LastName}");
                    Console.WriteLine();
                    Console.WriteLine($"Знак зодiаку: {person.ZodiakSign}");
                    Console.WriteLine();
                    Console.WriteLine($"Дата народження: {person.Date}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Людини з прiзвищем {surname} не знайдено.");
            }

        }
    }
}