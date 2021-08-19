using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Creator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private static int _count = 0;
        public Creator(string name)
        {
            Id = _count++;
            Name = name;
        }

        public string GetCreator()
        {
            return $"{Id:D6} - {Name:20}";
        }
    }
}
