using System;

namespace Topic_8_Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var scaner = new Scanner();
            scanner.ScanDirectory(@"C:\Users\linas.k\OneDrive - Baltijos Brasta\Desktop\New folder\visma-php-homework");
            scanner.SaveChanges();
        }
    }
}
