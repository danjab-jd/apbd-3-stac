using System;

namespace APBD3.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public string StudyTime { get; set; }
        public int Number { get;  set; }
        public string Birthday { get; set; }
        public string Email { get;  set; }
        public string FatherName { get;  set; }
        public string MotherName { get;  set; }
       


        public Student(String name, String surname, String faculty, String studyTime, int number, String birthday,
            String email, String mothersName, String fathersName)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
            this.Email = email;
            this.Faculty = faculty;
            this.StudyTime = studyTime;
            this.FatherName = fathersName;
            this.MotherName = mothersName;
            this.Number = number;
        }

        public Student()
        {
            this.Name = "";
            this.Surname = "";
            this.Birthday = "";
            this.Email = "";
            this.Faculty = "";
            this.StudyTime = "";
            this.FatherName = "";
            this.MotherName = "";
            this.Number = 1;
        }

        public int CompareTo(Student other)
        {
            if (String.Compare(Name, other.Name) == 0)
            {
                if (String.Compare(Surname, other.Surname) == 0)
                {
                    if (Number == other.Number)
                    {
                        return 0;
                    }

                }
            }
            return -1;
        }
    }

}