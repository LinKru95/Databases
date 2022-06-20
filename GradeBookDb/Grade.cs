using Microsoft.EntityFrameworkCore;

namespace GradeBookDb
{
    [Keyless]
    public class Grade
    {
        public int GradeValue { get; set; }
        public int StudentID { get; set; }
        public int NoOfTrimester { get; set; }
        public Grade() { }
        public Grade(int gradeValue, int studentID, int noOfTrimester)
        {
            GradeValue = gradeValue;
            StudentID = studentID;
            NoOfTrimester = noOfTrimester;
        }
    }
}
