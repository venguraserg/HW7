using System;
using System.Collections;
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

        public Repository(List<Note> notes)
        {
            Notes = notes;
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
                Notes.Add(new Note(new DateTime(2021,random.Next(1,13), random.Next(1, 30)), ConsoleHelper.GetRandomString(5, random),
                    ConsoleHelper.GetRandomString(150, random),
                    ConsoleHelper.GetRandomString(10, random), 
                    (Status)random.Next(1, 4)));
            }
        }

        /// <summary>
        /// Метод изменения записи
        /// </summary>
        internal void UpdateNote(Note editNote ,int noteIndex)
        {
            Notes[noteIndex] = editNote;
        }

        /// <summary>
        /// Метод удаления записи по индексу
        /// </summary>
        internal void DeleteNote(int noteIndex)
        {
            Notes.RemoveAt(noteIndex);
        }

        /// <summary>
        /// Метод удаления ВСЕХ записей
        /// </summary>
        internal void DeleteAllNote()
        {
            Notes.Clear();            
        }

        
    }
}
