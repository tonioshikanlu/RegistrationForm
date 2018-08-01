using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Controllers
{
    [Authorize]
    public class RegistersController : Controller
    {
        private readonly MvcRegisterContext _context;

        public RegistersController(MvcRegisterContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registers.ToListAsync());
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcRegister = await _context.Registers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mvcRegister == null)
            {
                return NotFound();
            }

            return View(mvcRegister);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,DateAdded,Address,Class,Age")] MvcRegister mvcRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mvcRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mvcRegister);
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcRegister = await _context.Registers.FindAsync(id);
            if (mvcRegister == null)
            {
                return NotFound();
            }
            return View(mvcRegister);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,DateAdded,Address,Class,Age")] MvcRegister mvcRegister)
        {
            if (id != mvcRegister.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mvcRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MvcRegisterExists(mvcRegister.ID))
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
            return View(mvcRegister);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcRegister = await _context.Registers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mvcRegister == null)
            {
                return NotFound();
            }

            return View(mvcRegister);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mvcRegister = await _context.Registers.FindAsync(id);
            _context.Registers.Remove(mvcRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MvcRegisterExists(int id)
        {
            return _context.Registers.Any(e => e.ID == id);
        }
    }
}
