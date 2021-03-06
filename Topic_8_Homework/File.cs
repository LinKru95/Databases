using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_8_Homework
{
    public class File
    {
        public Guid Id { get; set; }
        [ForeignKey("Folder")]
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public string FullDirectory { get; set; }
        public long Size { get; set; }
        public File(string name, string fullDirectory, long size)
        {
            Id = Guid.NewGuid();
            Name = name;
            FullDirectory = fullDirectory;
            Size = size;
        }
    }
}
