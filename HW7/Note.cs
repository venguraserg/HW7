using System;

namespace HW7
{
    public class Note
    {
        //свойства
        
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public Status Status { get; set; }

        //конструктор
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Note()
        {

        }

        public Note(string title, string content, string creator, Status status)
        {
            CreateDate = DateTime.Now.Date;
            Title = title;
            Content = content;
            Creator = creator;
            Status = status;
        }

        public Note(DateTime createDate, string title, string content, string creator, Status status)
        {
            CreateDate = createDate;
            Title = title;
            Content = content;
            Creator = creator;
            Status = status;
        }



    }
}
