using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static int _count = 0;
        //конструктор

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
