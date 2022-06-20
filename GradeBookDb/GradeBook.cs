using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBookDb
{
    public class GradeBook
    {
        public StudentRepository StudentRepo { get; set; }
        public GradeRepository GradeRepo { get; set; }
        public GradeBook() { }
        public GradeBook(StudentRepository studentRepo,
                         GradeRepository gradeRepo)
        {
            StudentRepo = studentRepo;
            GradeRepo = gradeRepo;
        }
        public void GradeBookControl()
        {
            Console.WriteLine("Welcome to Gradebook");
            bool repeat = true;
            string userInput;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("MENIU\n[1]-Perziureti pazymius\n[2]-Perziureti vidurkius\n[3]-Prideti pazymi\n[4]-Spausdinti ataskaita\n[5]-Iseiti is programos");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        ShowGradesControl();
                        break;
                    case "2":
                        Console.Clear();
                        ShowAverageControl();
                        break;
                    case "3":
                        Console.Clear();
                        AddGrade();
                        break;
                    case "4":
                        Console.Clear();
                        //GenerateTextReport();
                        break;
                    case "5":
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Bloga ivestis, bandykite dar karta");
                        Console.ReadLine();
                        break;
                }
            }           
        }
        private void ShowGradesControl()
        {
            Console.WriteLine("Iveskite mokinio, kurio pazymius norite pamatyti, varda arba ID:\n");

            StudentRepo.ShowStudents();

            var student = GetStudent();

            Console.Clear();
            Console.WriteLine("[1]-Pirmo trimestro pazymiai\n[2]-Antro trimestro pazymiai\n[3]-Trecio trimestro pazymiai\n[4]-Visu metu pazymiai");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    ShowGrades(GetGrades(student, 1));
                    break;
                case "2":
                    Console.Clear();
                    ShowGrades(GetGrades(student, 2));
                    break;
                case "3":
                    Console.Clear();
                    ShowGrades(GetGrades(student, 3));
                    break;
                case "4":
                    Console.Clear();
                    ShowGrades(GetGrades(student));
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Bloga ivestis, bandykite dar karta");
                    Console.ReadLine();
                    break;
            }
        }
        private Student GetStudent()
        {    
            string inputString = Console.ReadLine();

            if (Int32.TryParse(inputString, out int inputInt))
            {
                return StudentRepo.RetrieveByID(inputInt);
            }
            else
            {
                return StudentRepo.RetrieveByName(inputString);
            }
        }
        public void ShowGrades(List<int> grades)
        {
            foreach (var item in grades)
            {
                    Console.Write($"{item}, ");
            }
            Console.ReadLine();
        }
        public void AddGrade()
        {
            Console.WriteLine("Iveskite studento, kuriam norite prideti pazymi, ID:\n");

            StudentRepo.ShowStudents();

            int studentId = Int32.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Iveskite pazymi:");

            int grade = Int32.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Iveskite i kuri trimestra norite ivesti pazymi:");

            int noOfTrimester = Int32.Parse(Console.ReadLine());

            GradeRepo.AddGrade(grade, studentId, noOfTrimester);
        }
        public void ShowAverageControl()
        {
            Console.WriteLine("Iveskite mokinio, kurio pazymiu vidurki norite pamatyti, varda arba ID:\n");

            StudentRepo.ShowStudents();

            var student = GetStudent();

            Console.Clear();
            Console.WriteLine("[1]-Pirmo trimestro vidurkis\n[2]-Antro trimestro vidurkis\n[3]-Trecio trimestro vidurkis\n[4]-Visu metu vidurkis");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    ShowAverage(GetGrades(student, 1), 1);
                    break;
                case "2":
                    Console.Clear();
                    ShowAverage(GetGrades(student, 2), 2);
                    break;
                case "3":
                    Console.Clear();
                    ShowAverage(GetGrades(student, 3), 3);
                    break;
                case "4":
                    Console.Clear();
                    ShowAverage(GetGrades(student), 0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Bloga ivestis, bandykite dar karta");
                    Console.ReadLine();
                    break;
            }
        }
        private void ShowAverage(List<int> grades, int noOfTrimester)
        {
            if (noOfTrimester == 1 || noOfTrimester == 2 || noOfTrimester == 3)
            {
                Console.WriteLine($"{noOfTrimester}-ojo trimestro pazymiu vidurkis yra: {Math.Round(grades.Average(), 2)}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Visu metu pazymiu vidurkis yra: {Math.Round(grades.Average(), 2)}");
                Console.ReadLine();
            }
        }
        public List<int> GetGrades(Student student)
        {
            List<int> grades = new List<int>();

            foreach (var item in GradeRepo.Retrieve())
            {
                if (item.StudentID == student.ID)
                {
                    grades.Add(item.GradeValue);
                }
            }

            return grades;
        }
        public List<int> GetGrades(Student student, int noOfTrimester)
        {
            List<int> grades = new List<int>();

            foreach (var item in GradeRepo.Retrieve())
            {
                if (item.StudentID == student.ID && item.NoOfTrimester == noOfTrimester)
                {
                    grades.Add(item.GradeValue);
                }
            }

            return grades;
        }
        //public void GeneratePdfReport()
        //{
        //    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        //    Console.WriteLine("Iveskite mokinio, kurio pazymiu ataskaita norite sukurti, varda arba ID:\n ");

        //    StudentRepo.ShowStudents();

        //    var student = GetStudent();

        //    var grades = GetGrades(student);

        //    string report = $"Mokinio vardas: {student.Name}\n\nVisu metu pazymiai:\n";

        //    foreach (var item in grades)
        //    {
        //        report += $"{item}  ";
        //    }

        //    report += $"\nMetinis vidurkis lygus:\n {grades.Average()}";

        //    PdfDocument document = new PdfDocument();

        //    PdfPage page = document.AddPage();

        //    XGraphics gfx = XGraphics.FromPdfPage(page);

            

        //    XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

        //    gfx.DrawString(report, font, XBrushes.Black,
        //                    new XRect(0, 0, page.Width, page.Height),
        //                    XStringFormats.Center);

        //    const string filename = "Pazymiai.pdf";
        //    document.Save(filename);

            //Process.Start(filename);
        //}
        //public void GenerateTextReport()
        //{
        //    string path = @"C:\Users\linas.k\OneDrive - Baltijos Brasta\Desktop\New folder\Skaidrės\GradeReport.txt";

        //    Console.WriteLine("Iveskite mokinio, kurio pazymiu ataskaita norite sukurti, varda arba ID:\n ");

        //    StudentRepo.ShowStudents();

        //    var student = GetStudent();

        //    var grades = GetGrades(student);

        //    string report = $"Mokinio vardas: {student.Name}\n\nVisu metu pazymiai:\n";

        //    foreach (var item in grades)
        //    {
        //        report += $"{item}  ";
        //    }

        //    report += $"\nMetinis vidurkis lygus:\n {grades.Average()}";

        //    System.IO.File.WriteAllText(path, report);

        //}
    }
}