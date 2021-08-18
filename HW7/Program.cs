using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Note> notebook = new List<Note>();
            notebook = Autocomplete(100);

            Noteboock book = new Noteboock();

            book.Records = Autocomplete(100);

            foreach (var item in book.Records)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Конец программы. Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
        }

        private static List<Note> Autocomplete(int items)
        {
            List<Note> notebook = new List<Note>();
            for (int i = 0; i < items; i++)
            {
                notebook.Add(new Note("content" + i, "creator" + i, Status.Actual));
            }
            return notebook;
        }
    }
}
