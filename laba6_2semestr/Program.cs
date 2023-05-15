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

        public Zodiak(string firstName, string lastName, string zodiakSign, int[] dateOfBirth,string date)
        {
            FirstName = firstName;
            LastName = lastName;
            ZodiakSign = zodiakSign;
            DateOfBirth = dateOfBirth;
            Date = string.Join(".", dateOfBirth);
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
        //public static bool IsDateOfBirthValid(string zodiacSign, int[] dateOfBirth)
        //{
        //    switch (zodiacSign)
        //    {
        //        case "Овен":
        //            return (dateOfBirth[0] >= 21 && dateOfBirth[1] == 3) || (dateOfBirth[0] <= 20 && dateOfBirth[1] == 4);
        //        case "Телець":
        //            return (dateOfBirth[0] >= 21 && dateOfBirth[1] == 4) || (dateOfBirth[0] <= 20 && dateOfBirth[1] == 5);
        //        case "Близнюки":
        //            return (dateOfBirth[0] >= 21 && dateOfBirth[1] == 5) || (dateOfBirth[0] <= 21 && dateOfBirth[1] == 6);
        //        case "Рак":
        //            return (dateOfBirth[0] >= 22 && dateOfBirth[1] == 6) || (dateOfBirth[0] <= 22 && dateOfBirth[1] == 7);
        //        case "Лев":
        //            return (dateOfBirth[0] >= 23 && dateOfBirth[1] == 7) || (dateOfBirth[0] <= 22 && dateOfBirth[1] == 8);
        //        case "Діва":
        //            return (dateOfBirth[0] >= 23 && dateOfBirth[1] == 8) || (dateOfBirth[0] <= 22 && dateOfBirth[1] == 9);
        //        case "Терези":
        //            return (dateOfBirth[0] >= 23 && dateOfBirth[1] == 9) || (dateOfBirth[0] <= 22 && dateOfBirth[1] == 10);
        //        case "Скорпіон":
        //            return (dateOfBirth[1] == 10 && dateOfBirth[0] >= 23) || (dateOfBirth[1] == 11 && dateOfBirth[0] <= 21);
        //        case "Стрілець":
        //            return (dateOfBirth[0] >= 22 && dateOfBirth[1] == 11) || (dateOfBirth[0] <= 21 && dateOfBirth[1] == 12);
        //        case "Козеріг":
        //            return (dateOfBirth[0] >= 22 && dateOfBirth[1] == 12) || (dateOfBirth[0] <= 20 && dateOfBirth[1] == 1);
        //        case "Водолій":
        //            return (dateOfBirth[0] >= 21 && dateOfBirth[1] == 1) || (dateOfBirth[0] <= 18 && dateOfBirth[1] == 2);
        //        case "Риби":
        //            return (dateOfBirth[0] >= 19 && dateOfBirth[1] == 2) || (dateOfBirth[0] <= 20 && dateOfBirth[1] == 3);
        //        default:
        //            return false;
        //    }
        //}
        static void Main(string[] args)
        {
            Console.Write("Введiть кiлькiсть людей: ");
            int n = int.Parse(Console.ReadLine());
            Zodiak[] people = new Zodiak[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Людина №{i + 1}");
                Console.Write("Iм'я: ");
                people[i].FirstName = Console.ReadLine();
                Console.Write("Прiзвище: ");
                people[i].LastName = Console.ReadLine();
                Console.Write("Знак зодiаку: ");
                people[i].ZodiakSign = Console.ReadLine();
                Console.Write("Дата народження (у форматi ДД.ММ.РРРР): ");
                people[i].DateOfBirth = Console.ReadLine().Split('.').Select(int.Parse).ToArray();
                people[i].Date = string.Join(".", people[i].DateOfBirth);
                //bool isValid = IsDateOfBirthValid(people[i].ZodiakSign, people[i].DateOfBirth);
                //if (isValid)
                //{
                //    Console.WriteLine("знак i дата народження не вiдповiдають одне одному.");
                //    Console.WriteLine("змiнiть або дату народження, або знак зодiаку.");
                //    Console.Write("Змiнити дату народження? (так / нi): ");
                //    string changeDateAnswer = Console.ReadLine();

                //    if (changeDateAnswer.ToLower() == "так")
                //    {
                //        Console.Write("Нова дата народження (у форматi ДД.ММ.РРРР): ");
                //        int[] newDateOfBirth = Console.ReadLine().Split('.').Select(int.Parse).ToArray();
                //        isValid = IsDateOfBirthValid(people[i].ZodiakSign, newDateOfBirth);

                //        if (isValid)
                //        {
                //            people[i].DateOfBirth = newDateOfBirth;
                //            people[i].Date = string.Join(".", people[i].DateOfBirth);
                //            Console.WriteLine("Дата народження змiнена успiшно.");
                //        }
                //        else
                //        {
                //            Console.WriteLine("Нова дата народження не вiдповiдає змiнi знаку зодiаку.");
                //        }
                //    }

                //    Console.Write("Змiнити знак зодiаку? (так / нi): ");
                //    string changeZodiacAnswer = Console.ReadLine();

                //    if (changeZodiacAnswer.ToLower() == "так")
                //    {
                //        Console.Write("Новий знак зодiаку: ");
                //        string newZodiacSign = Console.ReadLine();
                //        isValid = IsDateOfBirthValid(newZodiacSign, people[i].DateOfBirth);

                //        if (isValid)
                //        {
                //            people[i].ZodiakSign = newZodiacSign;
                //            Console.WriteLine("Знак зодiаку змiнено успiшно.");
                //        }
                //        else
                //        {
                //            Console.WriteLine("Новий знак зодiаку не вiдповiдає змiнi дати народження.");
                //        }
                //    }
                //}
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