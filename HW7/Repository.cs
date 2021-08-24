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
        /// Конструктор репозитория
        /// </summary>
        public Repository()
        {
            Notes = new List<Note>();
        }

        /// <summary>
        /// Метод добавления записи в репозиторий
        /// </summary>
        /// <param name="title">Заголовок записи</param>
        /// <param name="content">Содержание записи</param>
        /// <param name="creator">Создатель записи</param>
        /// <param name="status">Статус записи</param>
        internal void AddNote(string title, string content, string creator, Status status)
        {
            Notes.Add(new Note(title, content, creator, status));
        }

        /// <summary>
        /// Метод изменения записи
        /// </summary>
        internal void AutocompliteRepository(int item)
        {
            var random = new Random();
            for (int i = 0; i < item; i++)
            {
                Notes.Add(new Note(ConsoleHelper.GetRandomString(5, random),
                    ConsoleHelper.GetRandomString(150, random),
                    ConsoleHelper.GetRandomString(10, random), 
                    (Status)random.Next(1, 4)));
            }

        }

        /// <summary>
        /// Метод вывода всех записей в коротком, с заголовками без содержания
        /// </summary>
        internal void PrintAllNotes() 
        {
            if (Notes.Count == 0)
            {
                Console.WriteLine("Записей нет");
            }
            else
            {
                Console.WriteLine("*******************************************************************");
                Console.WriteLine($"|  №  | Дата создания |     Заголовок    |  Создатель |   Статус   |");
                Console.WriteLine("*******************************************************************");

                for (var i = 0; i < Notes.Count(); i++)
                {
                    Console.WriteLine($"|{(i + 1),5}|{Notes[i].CreateDate.ToShortDateString(),15}|{Notes[i].Title,18}|{Notes[i].Creator,12}|{Notes[i].Status,12}|");
                }
            }
        }

        /// <summary>
        /// Метод вывода одной записи в развернутом виде
        /// </summary>
        internal void PrintOneNote(int noteIndex)
        {
            if (Notes.Count == 0)
            {
                Console.WriteLine("Записей нет");
            }
            else
            {

                Console.WriteLine($"Заметка  №: {(noteIndex + 1)}");
                Console.WriteLine($"Создана   : {Notes[noteIndex].CreateDate.ToShortDateString()}");
                Console.WriteLine($"Статус    : {Notes[noteIndex].Status}");
                Console.WriteLine($"Создатель : {Notes[noteIndex].Creator}");
                Console.WriteLine($"Заголовок : {Notes[noteIndex].Title}");
                Console.WriteLine("Текст Заметки:");
                Console.WriteLine($"{Notes[noteIndex].Content}");

            }
        }

        /// <summary>
        /// Метод изменения записи
        /// </summary>
        internal void UpdateNote(int noteIndex)
        {
            Notes[noteIndex] = new Note("111", "222", "333", Status.Actual);
        }
        /// <summary>
        /// Метод удаления записи
        /// </summary>
        internal void DeleteNote(int noteIndex)
        {
            Notes.RemoveAt(noteIndex);
        }
    }
}
