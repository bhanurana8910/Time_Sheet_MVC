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
    //Employee controller with permision.
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly Time_Sheet_MVCDatabaseContext _context;

        public EmployeesController(Time_Sheet_MVCDatabaseContext context)
        {
            _context = context;
        }

        // GET: Employees
        //gets all employees using a linq query.
        public IActionResult Index()
        {
            return View((from employee in _context.Employee select employee).ToList());
        }

        // GET: Employees/Details/5
        //Gets all details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  _context.Employee
                .FirstOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        //Gets the employee create form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the employee.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ContactPhoneNumber")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        //Gets the employee for  update using a linq query
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = (from employees in _context.Employee
                            where employees.Id == id
                            select employees).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactPhoneNumber")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        //Gets the employee for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  _context.Employee
                .FirstOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        //Deletes the employee uses a linq query to select the employee
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = (from employees in _context.Employee
                            where employees.Id == id
                            select employees).FirstOrDefault();
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the employee existance using a lamda query.
        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
