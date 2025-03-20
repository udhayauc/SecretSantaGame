using SecretSantaGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaGame.Services
{
    public class SecretSantaAssigner
    {
        public List<SecretSantaAssignment> AssignSecretSantas(List<Employee> employees, Dictionary<string, string> lastYearAssignments)
        {
            try
            {
                var random = new Random();
                var shuffledEmployees = employees.OrderBy(x => random.Next()).ToList();
                var assignments = new List<SecretSantaAssignment>();

                for(int i = 0; i < employees.Count; i++)
                {
                    var santa = employees[i];
                    var possibleChildren = shuffledEmployees.Where(e => e.Email != santa.Email && (lastYearAssignments[santa.Email] != e.Email || 
                    !lastYearAssignments.ContainsKey(santa.Email))).ToList();

                    if(possibleChildren.Count == 0)
                    {
                        throw new InvalidOperationException("Valid Secret Santa assignment could not be made.");
                    }

                    var secretChild = possibleChildren[random.Next(possibleChildren.Count)];
                    assignments.Add(new SecretSantaAssignment { Santa = santa, SecretChild = secretChild });
                    
                    shuffledEmployees.Remove(secretChild);
                }
                return assignments;
            }
            catch {
                return new List<SecretSantaAssignment>();
            }
        }
    }
}
