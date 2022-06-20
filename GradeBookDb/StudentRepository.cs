using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBookDb
{
    public class StudentRepository
    {
        public List<Student> Students { get; set; }
        public StudentRepository()
        {
            using var dbContext = new GradeBookContext();

            Students = new List<Student>();

            Students = dbContext.Students.ToList();
        }
        public Student RetrieveByID(int iD)
        {
            return Students.FirstOrDefault(x => x.ID == iD);
        }
        public Student RetrieveByName(string name)
        {
            return Students.FirstOrDefault(x => x.Name == name);
        }
        public void ShowStudents()
        {
            foreach (var item in Students)
            {
                Console.WriteLine($"Studento ID: {item.ID}, studento vardas: {item.Name}");
            }
        }
    }
}
