using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public static class ConsoleHelper
    {
        

        
        public static List<Note> Autocomplete(int items)
        {
            List<Note> notebook = new List<Note>();
            var random = new Random();
            for (int i = 0; i < items; i++)
            {
                notebook.Add(new Note("content" + random.Next(0, 10000000), new Creator("creator" + (random.Next(0, 10000000) - i)), (Status)random.Next(0, 3)));
            }
            return notebook;
        }

        public static void PrintNotes(List<Note> notebook)
        {
            foreach (var item in notebook)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
