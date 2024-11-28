using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.OOP
{
    public class Student
    {
        // Загальні дані про студента
        public string FullName { get; set; } // П.І.П.
        public string Faculty { get; set; }  // Факультет
        public string Department { get; set; } // Кафедра
        public string Course { get; set; } // Курс
        public string Room { get; set; }        // Номер кімнати
        public string Block { get; set; }         // Номер блоку
        public string CheckInDate { get; set; }  // Дата заселення
        public string CheckOutDate { get; set; } // Дата виселення


        // Конструктор для ініціалізації всіх полів
        public Student(string fullName, string faculty, string department, string course, string room, string block, string checkInDate, string checkOutDate)
        {
            FullName = fullName;
            Faculty = faculty;
            Department = department;
            Course = course;
            Room = room;
            Block = block;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }

}
