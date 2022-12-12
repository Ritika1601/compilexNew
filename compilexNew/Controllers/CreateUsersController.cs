using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using compilex.Models;

namespace compilex.Controllers
{
    public class CreateUsersController : Controller
    {
        private readonly compilexContext _context;

        public CreateUsersController(compilexContext context)
        {
            _context = context;
        }
        // GET: CreateUsers
        public async Task<IActionResult> HomePage()
        {
            return View(await _context.CreateUsers.ToListAsync());
        }
        // GET: CreateUsers
        public async Task<IActionResult> Index()
        {
              return View(await _context.CreateUsers.ToListAsync());
        }

        // GET: CreateUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CreateUsers == null)
            {
                return NotFound();
            }

            var createUser = await _context.CreateUsers
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (createUser == null)
            {
                return NotFound();
            }

            return View(createUser);
        }

        // GET: CreateUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreateUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password,FullName,EmailId,CurrentComapany,Designation,DateOfBirth,Industry,Position,Resume,Gender,CollegeName,YearOfPassing")] CreateUser createUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(createUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createUser);
        }

        // GET: CreateUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CreateUsers == null)
            {
                return NotFound();
            }

            var createUser = await _context.CreateUsers.FindAsync(id);
            if (createUser == null)
            {
                return NotFound();
            }
            return View(createUser);
        }

        // POST: CreateUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Password,FullName,EmailId,CurrentComapany,Designation,DateOfBirth,Industry,Position,Resume,Gender,CollegeName,YearOfPassing")] CreateUser createUser)
        {
            if (id != createUser.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(createUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreateUserExists(createUser.UserName))
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
            return View(createUser);
        }

        // GET: CreateUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CreateUsers == null)
            {
                return NotFound();
            }

            var createUser = await _context.CreateUsers
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (createUser == null)
            {
                return NotFound();
            }

            return View(createUser);
        }

        // POST: CreateUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CreateUsers == null)
            {
                return Problem("Entity set 'compilexContext.CreateUsers'  is null.");
            }
            var createUser = await _context.CreateUsers.FindAsync(id);
            if (createUser != null)
            {
                _context.CreateUsers.Remove(createUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreateUserExists(string id)
        {
          return _context.CreateUsers.Any(e => e.UserName == id);
        }
    }
}
