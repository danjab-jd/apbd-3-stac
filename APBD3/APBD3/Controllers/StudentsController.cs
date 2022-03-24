using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD3.Controllers
{
    //localhost:XXXXXX/XYZ
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // statyczna lista studentów z pliku dane.csv

        // w konstruktorze inicjalizacja kolekcji studentów


        [HttpGet]
        public IEnumerable<Student> GetStudentsList()
        {
            return null;
        }

        // GET: api/students/555
        [HttpGet("{indexNum}")]
        public Student GetStudentByIndex(int indexNum)
        {
            return null;
        }

        // DELETE: api/students/555
        [HttpDelete("{indexNum}")]
        public string DeleteStudent(int indexNum)
        {
            // kolekcja.Remove(obj)
            return "Student usunięty";
        }

    }
}
