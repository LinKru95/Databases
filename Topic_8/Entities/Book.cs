using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_8.Entities
{
    public class Book
    {
        [DefaultValue("newid()")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Category> Categories { get; set; }
        public Book(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Categories = new List<Category>();
        }
    }
}
