using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HayvanBarınagi.Models;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace HayvanBarınagi
{
    public class AnimalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalsController(ApplicationDbContext context)
        {
            _context = context;
        }
         

        [Authorize] 
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Animals.Include(a => a.AnimalTypes).Include(a => a.GenderType).Include(a => a.OwnedType);
            return View(await applicationDbContext.ToListAsync());
        }
         
        [Authorize] 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.AnimalTypes)
                .Include(a => a.GenderType)
                .Include(a => a.OwnedType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        [Authorize] 
        public IActionResult Create()
        {
            ViewData["AnimalTypeId"] = new SelectList(_context.AnimalTypes, "Id", "AnimalType");
            ViewData["GenderTypeId"] = new SelectList(_context.GenderType, "Id", "Gender");
            ViewData["OwnedTypeId"] = new SelectList(_context.OwnedType, "Id", "Owned");
            return View();
        }

 
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AnimalTypeId,GenderTypeId,Age,OwnedTypeId,Color")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalTypeId"] = new SelectList(_context.AnimalTypes, "Id", "AnimalType", animal.AnimalTypeId);
            ViewData["GenderTypeId"] = new SelectList(_context.GenderType, "Id", "Gender", animal.GenderTypeId);
            ViewData["OwnedTypeId"] = new SelectList(_context.OwnedType, "Id", "Owned", animal.OwnedTypeId);
            return View(animal);
        }
         
        [Authorize] 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["AnimalTypeId"] = new SelectList(_context.AnimalTypes, "Id", "AnimalType", animal.AnimalTypeId);
            ViewData["GenderTypeId"] = new SelectList(_context.GenderType, "Id", "Gender", animal.GenderTypeId);
            ViewData["OwnedTypeId"] = new SelectList(_context.OwnedType, "Id", "Owned", animal.OwnedTypeId);
            return View(animal);
        }
    
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AnimalTypeId,GenderTypeId,Age,OwnedTypeId,Color")] Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
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
            ViewData["AnimalTypeId"] = new SelectList(_context.AnimalTypes, "Id", "AnimalType", animal.AnimalTypeId);
            ViewData["GenderTypeId"] = new SelectList(_context.GenderType, "Id", "Gender", animal.GenderTypeId);
            ViewData["OwnedTypeId"] = new SelectList(_context.OwnedType, "Id", "Owned", animal.OwnedTypeId);
            return View(animal);
        }
         
        [Authorize] 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.AnimalTypes)
                .Include(a => a.GenderType)
                .Include(a => a.OwnedType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }
        

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }
    }
}
