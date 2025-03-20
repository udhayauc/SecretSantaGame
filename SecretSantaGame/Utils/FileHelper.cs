using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaGame.Utils
{
    public static class FileHelper
    {
        public static Dictionary<string, string> ReadLastYearAssignments(string filePath)
        {
            var assignments = new Dictionary<string, string>();
            if (!File.Exists(filePath)) return assignments;

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            while (csv.Read())
            {
                var santaEmail = csv.GetField("Santa_Email");  
                var secretChildEmail = csv.GetField("Secret_Child_Email");

                if (!string.IsNullOrEmpty(santaEmail) && !string.IsNullOrEmpty(secretChildEmail))
                {
                    assignments[santaEmail] = secretChildEmail;
                }
            }

            return assignments;
        }
    }
}
