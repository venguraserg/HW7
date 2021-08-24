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
        internal void AutocompliteRepository()
        {

        }

        /// <summary>
        /// Метод вывода всех записей в коротком, с заголовками без содержания
        /// </summary>
        internal void PrintAllNote() 
        {
            
        }

        /// <summary>
        /// Метод вывода одной записи в развернутом виде
        /// </summary>
        internal void PrintOneNote()
        {

        }

        /// <summary>
        /// Метод изменения записи
        /// </summary>
        internal void UpdateNote()
        {

        }
        /// <summary>
        /// Метод удаления записи
        /// </summary>
        internal void DeleteNote()
        {

        }
    }
}
