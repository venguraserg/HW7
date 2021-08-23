using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{   
    /// <summary>
    /// Класс репозитория
    /// </summary>
    public class Repository
    {
        /// <summary>
        ///  Свойство записи 
        /// </summary>
        public List<Note> Notes { get; set; }


        /// <summary>
        /// Метод добавления новой записи в репозиторий
        /// </summary>
        public void AddNote()
        {
            Console.WriteLine("Введите название заметки:");
            string title = Console.ReadLine();
            Console.WriteLine("Введите вашу заметку:");
            string content = Console.ReadLine();
            Console.WriteLine("Введите создателя заметки:");
            string creator = Console.ReadLine();
            Console.WriteLine($"Выберите статус 1 - Важная 2 - Актуальная 3 - Не важная");
            string status = Console.ReadLine();

            Note newNote = new Note(title, content, creator, (Status)int.Parse(status));
            Notes.Add(newNote);
            Console.WriteLine("Заявка внесена . . .");

        }
    }
}
