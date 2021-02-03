using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Time_Sheet_MVC.Models
{
    public class TimeRecord
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public Employee Employee { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime {get; set;}

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }



    }
}
