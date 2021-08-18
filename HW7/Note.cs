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
        public int Id { get; }
        public DateTime CreateTime { get; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public Status Status { get; set; }
        private static int _count = 0;
        //конструктор

        public Note(string content, string creator, Status status)
        {
            Id = _count++;
            CreateTime = DateTime.Now;
            Content = content;
            Creator = creator;
            Status = status;
        }
        public override string ToString()
        {
            return $"{Id}  {CreateTime}  {Content}  {Creator}   {Status}";
        }
    }
}
