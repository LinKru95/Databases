using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_8_Homework
{
    public class Folder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Folder(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
