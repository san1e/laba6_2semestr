// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        struct Book: IComparable<Book>
        {
            public string NameBook;
            public string Avtor;
            public int Year;
            public Book(string NameBook, string Avtor, int Year)
            {
                this.NameBook = NameBook;
                this.Avtor = Avtor;
                this.Year = Year;


            }
            public int CompareTo(Book obj)
            {
                return Year.CompareTo(obj.Year);
                //Book bk = (Book)obj;
                //if (Year > bk.Year)
                //{
                //    return 1;
                //}
                //else if(Year < bk.Year)
                //{
                //    return -1;
                //}
                //else
                //{
                //    return 0;
                //}
            }
        }


        static void Main(string[] args)
        {
            Book[] Book = new Book[3];
            for (int i = 0; i < Book.Length; i++)
            {
                Book[i].NameBook = Console.ReadLine();
                Book[i].Avtor = Console.ReadLine();
                Book[i].Year = int.Parse(Console.ReadLine());
            }
            Array.Sort(Book);
            string str = string.Join(" ", Book);
            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}