using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_BusinessLogic
{
    public class Scanner
    {
        private readonly IRepository _repository;
        public Scanner()
        {
            _repository = new ScannerRepository();
        }
        public void SaveChanges() => _repository.SaveChanges();
        public void ScanDirectory(string name)
        {
            try
            {
                foreach (var directoryPath in Directory.GetDirectories(name))
                {
                    ScanDirectory(directoryPath);
                }

                var folder = _repository.GetFolder(name) ?? new T8_Database.Entities.DB.Folder
                {
                    name = name,
                };

                ScanFiles(folder);
                UpdateFolder(folder);
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { throw; }
        }
        private void ScanFiles(T8_Database.Entities.DB.Folder folder)
        {
            try
            {
                foreach (var filePath in Directory.GetFiles(folder.Name))
                {
                    var fileInfo = new FileInfo(filePath);

                    if (folder.Files.FirstOrDefault(x => x.Name == fileInfo.Name) == null)
                    {
                        folder.Files.Add(new T8_Database.Entities.DB.File
                        {
                            Name = fileInfo.Name,
                            Size = fileInfo.Length,
                            FullDirectory = fileInfo.FullName,
                        });
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { throw; }
        }
        private void UpdateFolder(T8_Database.Entities.DB.Folder folder)
        {
            _repository.AddOrUpdate(folder);
        }
    }
}
