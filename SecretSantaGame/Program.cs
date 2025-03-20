using System;
using System.IO;
using SecretSantaGame.Models;
using SecretSantaGame.Services;
using SecretSantaGame.Utils;

class Program
{
    static void Main()
    {
        string employeesFile = "Employees.csv";
        string lastYearFile = "last_year_assignments.csv";
        string outputFile = "secret_santa_output.csv";

        var csvService = new CsvParserService();
        var secretSantaAssigner = new SecretSantaAssigner();

        var employees = csvService.ReadEmployeesFromCsv(employeesFile);
        var lastYearAssignments = FileHelper.ReadLastYearAssignments(lastYearFile);

        if(employees.Count < 2)
        {
            Console.WriteLine("Not enough employees to conduct Secret Santa.");
            return;
        }
        try
        {
            var assignments = secretSantaAssigner.AssignSecretSantas(employees, lastYearAssignments);
            csvService.WriteAssignmentstoCsv(outputFile, assignments);

            Console.WriteLine("Secret Santa assignments completed! Check output CSV.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}