using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skola.Models;


namespace Skola.Controllers
{
    public class StudentController : Controller
    {
        //static Studenti[] student = new Studenti[]
        //    {
        //    new Studenti { Id = 1, Ime = "Petar", Prezime = "Radovanović", JMBG ="0405997740034" , MestoRođenja = "Beograd" },
        //    new Studenti { Id = 2, Ime = "Miliica", Prezime = "Jovanović", JMBG = "2211997765012", MestoRođenja = "Subotica" },
        //    new Studenti { Id = 3, Ime = "Predrag", Prezime = "Simonovič", JMBG = "15029977200476", MestoRođenja = "Beograd" }
        //    };
        //public IActionResult Index()
        //{

        //    return View();

        //}
        //public IActionResult StudentInfo()
        //{

        //    return View(student);

        //}
        private readonly StudentiContext _context;

        public StudentController(StudentiContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Studenti.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studenti == null)
            {
                return NotFound();
            }

            return View(studenti);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,JMBG,MestoRođenja")] Studenti studenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studenti);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti.FindAsync(id);
            if (studenti == null)
            {
                return NotFound();
            }
            return View(studenti);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,JMBG,MestoRođenja")] Studenti studenti)
        {
            if (id != studenti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentiExists(studenti.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studenti);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studenti == null)
            {
                return NotFound();
            }

            return View(studenti);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studenti = await _context.Studenti.FindAsync(id);
            _context.Studenti.Remove(studenti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentiExists(int id)
        {
            return _context.Studenti.Any(e => e.Id == id);
        }

    }
}
