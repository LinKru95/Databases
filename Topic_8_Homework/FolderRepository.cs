using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_8_Homework
{
    public class FolderRepository
    {
        private readonly FolderContext _dbContext;
        public FolderRepository()
        {
            _dbContext = new FolderContext();
        }
        public void CreateFolder(Folder folder)
        {
            _dbContext.Folders.Add(folder);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
