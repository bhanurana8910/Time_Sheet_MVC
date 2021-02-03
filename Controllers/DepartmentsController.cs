using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Time_Sheet_MVC.Models;

namespace Time_Sheet_MVC.Controllers
{
    //Department controller with permission
    
    public class DepartmentsController : Controller
    {
        private readonly Time_Sheet_MVCDatabaseContext _context;

        public DepartmentsController(Time_Sheet_MVCDatabaseContext context)
        {
            _context = context;
        }

        // GET: Departments
        //Get all departments using a linq query
        public IActionResult Index()
        {
            return View( (from department in _context.Department select department).ToList());
        }

        // GET: Departments/Details/5
        //Gets the department details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department =  _context.Department
                .FirstOrDefault(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
        [Authorize]
        // GET: Departments/Create
        //Gets the creat department form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a department to the databse.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ContactPhoneNumber")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        [Authorize]
        // GET: Departments/Edit/5
        //Gets the department for edit using a  linq query
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = (from departments in _context.Department
                              where departments.Id == id
                              select departments).FirstOrDefault();
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [Authorize]
        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the department 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactPhoneNumber")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
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
            return View(department);
        }
        [Authorize]
        // GET: Departments/Delete/5
        //Gets the department for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Department
                .FirstOrDefault(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
        [Authorize]
        // POST: Departments/Delete/5
        //Removes a department uses a linq query to get the department.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = (from departments in _context.Department
                              where departments.Id == id
                              select departments).FirstOrDefault();
            _context.Department.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the department existance using a lamda query.
        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.Id == id);
        }
    }
}
