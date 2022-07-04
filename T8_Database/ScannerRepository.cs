using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_Database
{
    public class ScannerRepository : IRepository
    {
        private readonly ScannerContext _context;
        public ScannerRepository()
        {
            _context = new ScannerContext();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public Entities.DB.Folder? GetFolder(string folderName)
        {
            return _context.Folders.Include(x => x.Files).FirstOrDefault(x => x.Name == folderName);
        }
        public void AddOrUpdate(Entities.DB.Folder folder)
        {
            if (folder.Id == Guid.Empty)
            {
                _context.Add(folder);
            }
            else
            {
                _context.Update(folder);
            }
        }

    }
}
