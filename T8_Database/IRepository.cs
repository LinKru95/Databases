using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_Database
{
    public interface IRepository
    {
        void SaveChanges();
        Entities.DB.Folder? GetFolder(string folderName);
        void AddOrUpdate(T8_Database.Entities.DB.Folder folder);
    }
}
