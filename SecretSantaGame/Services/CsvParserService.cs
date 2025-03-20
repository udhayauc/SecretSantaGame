using CsvHelper;
using CsvHelper.Configuration;
using SecretSantaGame.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaGame.Services
{
    public class CsvParserService
    {
        public List<Employee> ReadEmployeesFromCsv(string filePath)
        {
            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

                var employees = csv.GetRecords<Employee>().ToList();
                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
                return new List<Employee>();
            }
        }

        public void WriteAssignmentstoCsv(string filePath, List<SecretSantaAssignment> assignments)
        {
            try
            {
                using var writer = new StreamWriter(filePath);
                using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));

                csv.WriteRecords(assignments.Select(a => new
                {
                    Santa_Name = a.Santa.Name,
                    Santa_Email = a.Santa.Email,
                    Secret_Child_Name = a.SecretChild.Name,
                    Secret_Child_Email = a.SecretChild.Email,
                }));
            }
            catch (Exception ex) {
                Console.WriteLine($"Error writing CSV file: {ex.Message}");
            }
        }
    }
}
