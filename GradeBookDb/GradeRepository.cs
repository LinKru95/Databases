using System.Collections.Generic;
using System.Linq;


namespace GradeBookDb
{
    public class GradeRepository
    {
        public List<Grade> Grades { get; set; }
        public GradeRepository()
        {
            using var dbContext = new GradeBookContext();

            Grades = new List<Grade>();

            Grades = dbContext.Grades.ToList();
        }
        public Grade RetrieveByID(int studentID)
        {
            return Grades.FirstOrDefault(x => x.StudentID == studentID);
        }
        public Grade RetrieveByTrimester(int noOfTrimester)
        {
            return Grades.FirstOrDefault(x => x.NoOfTrimester == noOfTrimester);
        }
        public List<Grade> GetByStudentId(int id) 
        {
            return Grades.Where(x => x.StudentID == id && x.NoOfTrimester == 2).ToList();
        }
        public List<Grade> Retrieve()
        {
            return Grades;
        }
        public void AddGrade(int grade, int studentID, int noOfTrimester)
        {
            Grades.Add(new Grade(grade, studentID, noOfTrimester));
        }
    }
}
