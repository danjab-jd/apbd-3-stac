using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using APBD3.Models;
using Microsoft.AspNetCore.Http;


namespace APBD3.Controllers
{
    //localhost:XXXXXX/XYZ
    [ApiController]
    [Route("api/Students")]
    public class StudentsController : ControllerBase
    {
        public static List<Student> Students;
        
        // statyczna lista studentów z pliku dane.csv
        // w konstruktorze inicjalizacja kolekcji studentów
        
        [HttpGet]
        public IEnumerable<Student> GetStudentsList()
        {
            return Students;
        }
        
        // GET: api/students/555
        [HttpGet("{indexNumStr}")]
        public IActionResult GetStudentByIndex(string indexNumStr)
        {
            string resultString = Regex.Match(indexNumStr, @"\d+").Value;
            int indexNum;
            try
            {
                indexNum = Int32.Parse(resultString);
            }
            catch (Exception ignored)
            {
                return new StatusCodeResult(400);
            }
            
            
            Student toReturn = Students.Find(student => student.Number == indexNum);
            
            return toReturn == null ? new StatusCodeResult(204) :
                                      new JsonResult(toReturn){ StatusCode = StatusCodes.Status200OK};
            
        }
        
        
        // DELETE: api/students/555
        [HttpDelete("{indexNumStr}")]
        public IActionResult DeleteStudent(string indexNumStr)
        {
            string resultString = Regex.Match(indexNumStr, @"\d+").Value;
            int indexNum;
            try
            {
                indexNum = Int32.Parse(resultString);
            }
            catch (Exception ignored)
            {
                return new StatusCodeResult(400);
            }
            
            bool isRemoved = Students.Remove(Students.SingleOrDefault(student => student.Number == indexNum));
            //return isRemoved ? "Student usunięty" : "Student z ID " + indexNum + " nie został znaleziony";
            return isRemoved ? new StatusCodeResult(200) : new StatusCodeResult(204);
        }
        
       
        // PUT: api/students/
        [HttpPut]
        public IActionResult PutStudent(Student student)
        {
            if (
                student.Name == null ||
                student.Surname == null ||
                student.Birthday == null ||
                student.Email == null ||
                student.Faculty == null ||
                student.StudyTime == null
            )
                return new StatusCodeResult(400);

            if (Students.Find(instance => instance.Number == student.Number) != null)
                return new StatusCodeResult(400);
            if (student.Name.Length <= 1 || student.Surname.Length <= 1)
                return new StatusCodeResult(400);
            
            Students.Add(student);
            return new StatusCodeResult(200);
        }
    }
}
