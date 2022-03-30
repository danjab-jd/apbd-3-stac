using APBD3.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<StudentDTO> GetStudentsList()
        {
            return null;
        }

        [HttpPost]
        public string AddStudent(StudentDTO studentDTO)
        {
            return "Student dodany";
        }

        // GET: api/students/555
        [HttpGet("{indexNum}")]
        public StudentDTO GetStudentByIndex(int indexNum)
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

        // PUT: api/students/555
        [HttpPut("{indexNum}")]
        public string UpdateStudent(StudentDTO studentDTO)
        {
            return "Student zaktualizowany";
        }

    }
}
