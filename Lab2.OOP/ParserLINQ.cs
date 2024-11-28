using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2.OOP
{
    class ParserLINQ : IParser
    {
        public List<Student> Search(string filePath)
        {
            List<Student> result = new List<Student>();
            // Завантаження XML-документа
            XDocument xmlDoc = XDocument.Load(filePath);

            // Виконання запиту LINQ для отримання інформації про студентів
            var students = from student in xmlDoc.Descendants("Student")
                           select new
                           {
                               FullName = student.Element("FullName")?.Value,
                               Faculty = student.Element("Faculty")?.Value,
                               Department = student.Element("Department")?.Value,
                               Course = student.Element("Course")?.Value,
                               Room = student.Element("Room")?.Value,
                               Block = student.Element("Block")?.Value,
                               CheckInDate = student.Element("CheckInDate")?.Value,
                               CheckOutDate = student.Element("CheckOutDate")?.Value
                           };
            foreach (var student in students)
            {
                Student st = new Student(student.FullName, student.Faculty, student.Department, student.Course, student.Room, student.Block, student.CheckInDate, student.CheckOutDate);
                result.Add(st);
            }
            return result;
            
        }
    }
}
