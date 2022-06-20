namespace GradeBookDb
{
    public class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Student() { }
        public Student(string name, int iD)
        {
            Name = name;
            ID = iD;
        }
    }
}
