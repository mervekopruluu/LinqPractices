using System;
using System.Linq;
using LinqPractices.DbOperations;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            //Find
            Console.WriteLine("*** Find ***");

            var student = _context.Students.Find(1);
            Console.WriteLine(student.Name);


            //FirstOrDefault
            Console.WriteLine();
            Console.WriteLine("*** FirstOrDefault ***");

            student = _context.Students.Where(x => x.Surname == "Arda").FirstOrDefault();
            Console.WriteLine(student.Name);


            //SingleOrDefault
            Console.WriteLine();
            Console.WriteLine("*** SinglrOrDefault ***");

            student = _context.Students.SingleOrDefault(x => x.Name == "Deniz");
            Console.WriteLine(student.Surname);


            //ToList
            Console.WriteLine();
            Console.WriteLine("*** ToList ***");

            var studentList = _context.Students.Where(x => x.StudentId == 2).ToList();
            Console.WriteLine(studentList.Count());


            //OrderBy
            Console.WriteLine();
            Console.WriteLine("*** OrderBy ***");

            students = _context.Students.OrderBy(x => x.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId + " - " + st.Name + " " + st.Surname);
            }


            //OrderByDescending
            Console.WriteLine();
            Console.WriteLine("*** OrderByDescending ***");

            students = _context.Students.OrderByDescending(x => x.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId + " - " + st.Name + " " + st.Surname);
            }


            //Anonymous Object Result
            Console.WriteLine();
            Console.WriteLine("*** Anonymous Object Result ***");

            var anonymousObjResult = _context.Students
                               .Where(x => x.ClassId == 2)
                               .Select(x => new
                               {
                                   Id = x.StudentId,
                                   FullName = x.Name + " " + x.Surname
                               });

            foreach (var obj in anonymousObjResult)
            {
                Console.Write(obj.Id + " - " + obj.FullName);
            }


            //Group By
            // Console.WriteLine();
            // Console.WriteLine("*** Group By ***");

            // var s = _context.Students.GroupBy(s => s.StudentId);
            // foreach (var groupItem in s)
            // {
            //     Console.WriteLine(groupItem.Key);

            //     foreach (var std in groupItem)
            //     {
            //         Console.WriteLine(std.StudentId);
            //     }
            // }


            //Parameterized Query
            Console.WriteLine();
            Console.WriteLine("*** Parameterized Query ***");

            string name = "Merve";
            var std = _context.Students
                        .Where(s => s.Name == name)
                        .FirstOrDefault<Student>();
            Console.WriteLine(std.StudentId +" - "+ std.Name + " "+std.Surname);

        }
    }
}
