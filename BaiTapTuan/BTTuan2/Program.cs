using System;
using System.Collections.Generic;
using System.Linq;

namespace BTTuan2
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student() {Id = 2389, Name = "An", Age = 16},
                new Student() {Id = 2432, Name = "Binh", Age = 17},
                new Student() {Id = 3544, Name = "Anh", Age = 15},
                new Student() {Id = 4345, Name = "Tu", Age = 18},
                new Student() {Id = 5765, Name = "Manh", Age = 14}
            };

            Console.WriteLine("Danh sach hoc sinh:");
            students.ForEach(s => Console.WriteLine($"ID: {s.Id} - HoTen: {s.Name} - Tuoi: {s.Age}"));

            Console.WriteLine("\nHoc sinh 15-18 tuoi:");
            var age15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            foreach (var s in age15to18)
                Console.WriteLine($"ID: {s.Id} - HoTen: {s.Name} - Tuoi: {s.Age}");

            Console.WriteLine("\nHoc sinh ten bat dau bang A:");
            var startWithA = students.Where(s => s.Name.StartsWith("A"));
            foreach (var s in startWithA)
                Console.WriteLine($"ID: {s.Id} - HoTen: {s.Name} - Tuoi: {s.Age}");

            Console.Write("\nTong tuoi cua toan bo hoc sinh: ");
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine(totalAge);

            Console.WriteLine("\nHoc sinh lon tuoi nhat:");
            int maxAge = students.Max(s => s.Age);
            var oldest = students.Where(s => s.Age == maxAge);
            foreach (var s in oldest)
                Console.WriteLine($"ID: {s.Id} - HoTen: {s.Name} - Tuoi: {s.Age}");

            Console.WriteLine("\nDanh sach sap xep theo tuoi tang dan:");
            var sorted = students.OrderBy(s => s.Age);
            foreach (var s in sorted)
                Console.WriteLine($"ID: {s.Id} - HoTen: {s.Name} - Tuoi: {s.Age}");

        }
    }
}
