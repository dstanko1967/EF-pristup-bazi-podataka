using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skola.Models;

namespace Skola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiStudentController : Controller
    {
        static Studenti[] student = new Studenti[]
              {
            new Studenti { Id = 1, Ime = "Petar", Prezime = "Radovanović", JMBG ="0405997740034" , MestoRođenja = "Beograd" },
            new Studenti { Id = 2, Ime = "Miliica", Prezime = "Jovanović", JMBG = "2211997765012", MestoRođenja = "Subotica" },
            new Studenti { Id = 3, Ime = "Predrag", Prezime = "Simonovič", JMBG = "15029977200476", MestoRođenja = "Beograd" }
              };
        // GET: api/Api
        [HttpGet]
        public JsonResult GetStudent()
        {
            return Json(student);
        }

        // GET: api/Api/5
        [HttpGet("{id}", Name = "GetStudent")]
        public JsonResult GetStudent(int Id)
        {
            var studenti = student.FirstOrDefault(s => s.Id == Id);
            if (studenti == null)
            {
                return Json(NotFound());
            }

            return Json(studenti);

        }

    }
}