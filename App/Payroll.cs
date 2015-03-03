using System;
using System.Collections.Generic;

namespace PayProcessor.App {
    public class Payroll {
        private readonly List<Employee> _employees;

        public Payroll() {
            _employees = new List<Employee>();
        }

        public void Add(Employee employee) {
            _employees.Add(employee);
        }

        public void Run(DateTime today) {
            if (!today.DayOfWeek.Equals(DayOfWeek.Friday)) return;
            foreach (var employee in _employees) {
                employee.PayMaster.HeldPayChecks.Add(new Check {Amount = 40000});
            }
        }
    }
}