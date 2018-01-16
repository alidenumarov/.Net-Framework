using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab1.Models;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student> {
                new Student { FirstName = "Daryn", LastName = "Jeniskhanov", Age = 20},  
                new Student { FirstName = "Gaziz", LastName = "Ukan", Age = 24},  
                new Student { FirstName = "Sarah", LastName = "John", Age = 19},
                new Student { FirstName = "Ben", LastName = "Ten", Age = 21},
                new Student { FirstName = "Assem", LastName = "Li", Age = 18}
            };
            
            var courses = new List<Course> {
                new Course { Title = "Programming Language", Credits = 3, 
                    Students = new List<Student>{students.ElementAt(3), students.ElementAt(4)} },
                new Course { Title = "Pysical Education", Credits = 0,
                    Students = new List<Student>{students.ElementAt(0), students.ElementAt(1), students.ElementAt(2), students.ElementAt(3), students.ElementAt(4)} },
                new Course { Title = "Mobile App Development", Credits = 2,
                    Students = new List<Student>{students.ElementAt(0), students.ElementAt(1), students.ElementAt(2)} },
                new Course { Title = "Linear Algebra", Credits = 4, 
                    Students = new List<Student>{students.ElementAt(0), students.ElementAt(1)} },
                new Course { Title = "Management", Credits = 3,
                    Students = new List<Student>{students.ElementAt(2), students.ElementAt(4)}
                 }
            };
            
            var faculties = new List<Faculty> {
                new Faculty {Name = "FIT", Courses = new List<Course> {courses.ElementAt(0), courses.ElementAt(2)} },
                new Faculty {Name = "BS", Courses = new List<Course> {courses.ElementAt(4)} },
                new Faculty {Name = "Basic", Courses = new List<Course> {courses.ElementAt(1), courses.ElementAt(4)} },
                new Faculty {Name = "Math", Courses = new List<Course> {courses.ElementAt(0), courses.ElementAt(3)} },
                new Faculty {Name = "Geography", Courses = new List<Course>() /*{}*/ }
            };


            var teachers = new List<Teacher> {
                new Teacher { Name = "Senkebayeva A.", Courses = new List<Course> {courses.ElementAt(0), courses.ElementAt(2), courses.ElementAt(4)}},
                new Teacher { Name = "Bocharnikov M.", Courses = new List<Course> {courses.ElementAt(1)}},
                new Teacher { Name = "Bakhytova S.", Courses = new List<Course> {courses.ElementAt(0), courses.ElementAt(3)}},
                new Teacher { Name = "Djumadildayev A.", Courses = new List<Course> {courses.ElementAt(3)}},
                new Teacher { Name = "Mamyrova G.", Courses = new List<Course> {courses.ElementAt(0), courses.ElementAt(1), courses.ElementAt(4)}},
            };

            var organizations = new List<Organization> {
                new Organization { Name = "Faces", Students = new List<Student> {students.ElementAt(1), students.ElementAt(2), students.ElementAt(3), students.ElementAt(4)}},
                new Organization { Name = "Crystall", Students = new List<Student> {students.ElementAt(0), students.ElementAt(1), students.ElementAt(2), students.ElementAt(3), students.ElementAt(4)}},
                new Organization { Name = "Student Government", Students = new List<Student> {students.ElementAt(2), students.ElementAt(3), students.ElementAt(4)}},
                new Organization { Name = "Profit", Students = new List<Student> {students.ElementAt(0), students.ElementAt(3), students.ElementAt(4)}},
                new Organization { Name = "Parasat", Students = new List<Student> {students.ElementAt(4), students.ElementAt(0)}}
            };
            int threeCreditCourses = 0, numOfDarynsCourses = 0, maxCoursesOfStudent = 0,
            numOf21StudInCrys = 0, numOfTeachers3Courses = 0, numOfGazizSubscrOrgs = 0;
            string maxCourseName = "";
            ArrayList numOfStudInEachCourse, numOfCoursesInEachFaculty, numOfCoursesOfEachTeacher, numOfStudInEachOrg;
            numOfStudInEachCourse = new ArrayList();
            numOfCoursesInEachFaculty = new ArrayList();
            numOfCoursesOfEachTeacher = new ArrayList();
            numOfStudInEachOrg = new ArrayList();
            // IEnumerable<ArrayList> fitCourses = faculties.ElementAt(0);

            for(int i = 0; i < courses.Count; i++) {
                
                var curCourses = courses.ElementAt(i);

                for(int j = 0; j < curCourses.Students.Count; j++) {
                    var curStud = curCourses.Students.ElementAt(j);
                    if(curStud.FirstName.Contains("Daryn")) {
                        numOfDarynsCourses++;
                    }
                    if(curCourses.Credits == 3 && curCourses.Students.ElementAt(j).FirstName == "Assem")
                        threeCreditCourses++;
                }
                numOfStudInEachCourse.Add(curCourses.Students.Count);

                if(curCourses.Students.Count > maxCoursesOfStudent) {
                    maxCoursesOfStudent = curCourses.Students.Count;
                    maxCourseName = courses.ElementAt(i).Title;
                }
                var curFac = faculties.ElementAt(i);
                numOfCoursesInEachFaculty.Add(curFac.Courses.Count);


                var curTeach = teachers.ElementAt(i);
                numOfCoursesOfEachTeacher.Add(curTeach.Courses.Count);
                if(curTeach.Courses.Count == 3) numOfTeachers3Courses++;

                var curOrg = organizations.ElementAt(i);
                if(curOrg.Name == "Crystall") {
                    for(int j = 0; j < curOrg.Students.Count; j++)
                        if(curOrg.Students.ElementAt(j).Age >= 21) numOf21StudInCrys++;
                }
                numOfStudInEachOrg.Add(curOrg.Students.Count);
                for(int j = 0; j < curOrg.Students.Count; j++) {
                    if(curOrg.Students.ElementAt(j).FirstName == "Gaziz") numOfGazizSubscrOrgs++;
                }
            }

            var fitAndMath = faculties.ElementAt(0).Courses.Intersect(faculties.ElementAt(3).Courses);
            int fitAndMathCnt = 0;
            var fitAndBasic = faculties.ElementAt(0).Courses.Intersect(faculties.ElementAt(2).Courses);
            int fitAndBasicCnt = 0;

            Console.WriteLine("\nStudent Daryn learns " + numOfDarynsCourses + " course(s);");
            Console.WriteLine("Number of THREE credit courses which Assem learns = " + threeCreditCourses + ";");
            Console.WriteLine("Number of sudents in each course: ");
            for(int i = 0; i < courses.Count; i++) {
                Console.WriteLine(courses.ElementAt(i).Title + " " + numOfStudInEachCourse[i]);
            }
            Console.WriteLine("Course, in which amount of student(s) is maximum: " + maxCourseName + ", " + maxCoursesOfStudent + " student(s)");


            foreach(var i in fitAndMath) fitAndMathCnt++;    
            foreach(var i in fitAndBasic) fitAndBasicCnt++;    
            Console.WriteLine("\nNumber of same course(s) in FIT and Math Faculty: " + fitAndMathCnt);
            Console.WriteLine("Number of same course(s) in FIT and Basic Faculty: " + fitAndBasicCnt);
            Console.WriteLine("Number of course(s) in each faculty(ies): " + fitAndBasicCnt);
            for(int i = 0; i < faculties.Count; i++) {
                Console.WriteLine("In " + faculties.ElementAt(i).Name + " is " + numOfCoursesInEachFaculty[i] + " course(s)");
            }

            Console.WriteLine("\nNumber of courses of each teacher: ");
            for(int i = 0; i < teachers.Count; i++) {
                Console.WriteLine(teachers.ElementAt(i).Name + " has " + numOfCoursesOfEachTeacher[i] + " course(s)");
            }
            Console.WriteLine("Amount of teacher(s), which have 3 courses: " + numOfTeachers3Courses);
            int senkAndMam = 0;
            var senkAndMamCourses = teachers.ElementAt(0).Courses.Intersect(teachers.ElementAt(4).Courses);
            foreach(var i in senkAndMamCourses) senkAndMam++;
            Console.WriteLine("Amount of courses(s), that Senkebayeva A. and Mamyrova G. have: " + senkAndMam);
            
            Console.WriteLine("\nNumber of students, which are  >=21, in Crystall organization: " + numOf21StudInCrys);
            Console.WriteLine("Amount of students in each organization: ");
            for(int i = 0; i < organizations.Count; i++) {
                Console.WriteLine(numOfStudInEachOrg[i] + " student(s) in " + organizations.ElementAt(i).Name);
            }
            Console.WriteLine("Number of organizations, in which student Gaziz is: " + numOfGazizSubscrOrgs);
        }
    }
}
