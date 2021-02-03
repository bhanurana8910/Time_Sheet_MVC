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
    //Time record controller  with permission.
    [Authorize]
    public class TimeRecordsController : Controller
    {
        private readonly Time_Sheet_MVCDatabaseContext _context;

        public TimeRecordsController(Time_Sheet_MVCDatabaseContext context)
        {
            _context = context;
        }

        // GET: TimeRecords
        //Gets all time records using a lamda query.
        public IActionResult Index()
        {
            var time_Sheet_MVCDatabaseContext = _context.TimeRecord.Include(t => t.Department).Include(t => t.Employee);
            return View( time_Sheet_MVCDatabaseContext.ToList());
        }

        // GET: TimeRecords/Details/5
        //Gets details of time record using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecord = _context.TimeRecord
                .Include(t => t.Department)
                .Include(t => t.Employee)
                .FirstOrDefault(m => m.Id == id);
            if (timeRecord == null)
            {
                return NotFound();
            }

            return View(timeRecord);
        }

        // GET: TimeRecords/Create
        //Gets the create time record form.
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name");
            return View();
        }

        // POST: TimeRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a time record to database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,EmployeeId,DepartmentId,StartTime,EndTime,Date")] TimeRecord timeRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeRecord);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", timeRecord.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", timeRecord.EmployeeId);
            return View(timeRecord);
        }

        // GET: TimeRecords/Edit/5
        //Gets the time record for update using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecord = (from timerecords in _context.TimeRecord
                              where timerecords.Id == id
                              select timerecords).FirstOrDefault();
            if (timeRecord == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", timeRecord.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name", timeRecord.EmployeeId);
            return View(timeRecord);
        }

        // POST: TimeRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the time record 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,EmployeeId,DepartmentId,StartTime,EndTime,Date")] TimeRecord timeRecord)
        {
            if (id != timeRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeRecord);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeRecordExists(timeRecord.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", timeRecord.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", timeRecord.EmployeeId);
            return View(timeRecord);
        }

        // GET: TimeRecords/Delete/5
        //Gets the record for delete using a lamda query.
        public IActionResult  Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecord =  _context.TimeRecord
                .Include(t => t.Department)
                .Include(t => t.Employee)
                .FirstOrDefault(m => m.Id == id);
            if (timeRecord == null)
            {
                return NotFound();
            }

            return View(timeRecord);
        }

        // POST: TimeRecords/Delete/5
        //Deletes the record. uses  a linq query to get the record.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var timeRecord = (from timerecords in _context.TimeRecord
                              where timerecords.Id == id
                              select timerecords).FirstOrDefault();
            _context.TimeRecord.Remove(timeRecord);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the record using a lamda query.
        private bool TimeRecordExists(int id)
        {
            return _context.TimeRecord.Any(e => e.Id == id);
        }
    }
}
