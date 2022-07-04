using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_8.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Books = new List<Book>();
        }
    }
}
