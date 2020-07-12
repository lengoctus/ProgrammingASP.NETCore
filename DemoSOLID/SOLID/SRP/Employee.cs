using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Single responsibility principle
namespace DemoSOLID.SOLID.SRP
{
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(Employee em)
        {
            // Insert into employee table.
            return true;
        }
    }

    public class ReportGeneration
    {
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            // Report reneration with employee data.
        }
    }
}
