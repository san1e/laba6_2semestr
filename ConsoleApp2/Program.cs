namespace ConsoleApp2
{
    internal class Program
    {
        struct Book : IComparable<Book>
        {
            public string NameBook;
            public string Avtor;
            public int Year;
            public bool IsLib;
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
            foreach (Book book in Book)
            {
                Console.WriteLine($"Название: {book.NameBook}");
                Console.WriteLine($"Автор: {book.Avtor}");
                Console.WriteLine($"Год издания: {book.Year}");
                Console.WriteLine();
            }
                Console.ReadLine();
            }
        }
    }
