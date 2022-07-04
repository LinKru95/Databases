using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_8_Homework
{
    public class BusinessLogic
    {
        public BusinessLogic()
        {

            var repository = new FolderRepository();

            string path = @"C:\Users\linas.k\OneDrive - Baltijos Brasta\Desktop\Archyvas";

            GetAllFilesAndFoldersFromOneFolder(path, repository);

        }
        public void GetAllFilesFromOneFolder(string path, FolderRepository repository)
        {
            var folder = new Folder(path);           

            System.IO.DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles();

            foreach (FileInfo file in files)
            {
                folder.Files.Add(new File(file.Name, file.FullName, file.Length));
            }
            repository.CreateFolder(folder);
            repository.SaveChanges();
        }
        public void GetAllFilesAndFoldersFromOneFolder(string path, FolderRepository repository)
        {
            GetAllFilesFromOneFolder(path, repository);

            string[] directories = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);

            foreach (string directory in directories)
            {
                GetAllFilesAndFoldersFromOneFolder(directory, repository);
            }
        }
    }
}
