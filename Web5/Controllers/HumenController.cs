using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web5.Data;
using Web5.Models;

namespace Web5.Controllers
{
    public class HumenController : Controller
    {
        private readonly DatabaseContext _context;

        public HumenController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Humen
        public async Task<IActionResult> Index(string searchString, string sortOrder, int? ageSearch)
        {
            ViewData["AgeFilter"] = ageSearch; 
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var humans = from s in _context.Humans
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                humans = humans.Where(s => s.Name.Contains(searchString));
            }
            
            if (!(ageSearch==null))
            {
                humans = humans.Where(s => s.Age==ageSearch);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    humans = humans.OrderByDescending(s => s.Name);
                    break;
                default:
                    humans = humans.OrderBy(s => s.Name);
                    break;
            }
           return View(await humans.ToListAsync());
        }

        // GET: Humen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var human = await _context.Humans
               // .Include(c => c.Countrys)
                //.AsNoTracking()
                //.FirstOrDefaultAsync(m => m.ID == id);
            var human = await _context.Humans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (human == null)
            {
                return NotFound();
            }

            return View(human);
        }

        // GET: Humen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Humen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age")] Human human)
        {
            if (ModelState.IsValid)
            {
                _context.Add(human);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(human);
        }

        // GET: Humen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var human = await _context.Humans.FindAsync(id);
            if (human == null)
            {
                return NotFound();
            }
            return View(human);
        }

        // POST: Humen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age")] Human human)
        {
            if (id != human.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(human);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HumanExists(human.ID))
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
            return View(human);
        }

        // GET: Humen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Humans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (human == null)
            {
                return NotFound();
            }

            return View(human);
        }

        // POST: Humen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var human = await _context.Humans.FindAsync(id);
            _context.Humans.Remove(human);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HumanExists(int id)
        {
            return _context.Humans.Any(e => e.ID == id);
        }
    }
}
