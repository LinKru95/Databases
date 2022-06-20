using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic6_homework
{
    public class Book
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Page> Pages { get; set; } = null!;
        public Book(string name)
        {
            Name = name;
            Pages = new List<Page>();
        }
    }
}
