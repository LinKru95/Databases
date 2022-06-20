namespace GradeBookDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var gradeBook = new GradeBook(new StudentRepository(), new GradeRepository());

            gradeBook.GradeBookControl();
        }
    }
}
