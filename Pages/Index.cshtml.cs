using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Lab1.Pages
{
    public class IndexModel : PageModel
    {
    
        [BindProperty]
        public string Number1 { get; set; }

        [BindProperty]
        public string Number2 { get; set; }

        [BindProperty]
        public string Number3 { get; set; }

        public bool ShowStatistics
        {
            get
            {
                return NumberCount > 0;
            }
        }
        public bool ShowErrorMessage { get; set; }
        public int NumberCount { get; set; }
        public double Maximum { get; set; }
        public double Minimum { get; set; }
        public double Total { get; set; }
        public double Average { get; set; }

        public void OnPost()
        {
            ShowErrorMessage = false;
            NumberCount = 0;
            Total = 0;
            Average = 0;

            List<string> numbers = new List<string> { Number1, Number2, Number3 };

            List<double> validNumbers = ValidateNumbers(numbers);

            CalculateStatistics(validNumbers);

            ShowErrorMessage = NumberCount <= 0;

        }

        /// Validates input numbers and returns a list of valid doubles.
        private List<double> ValidateNumbers(List<string> input)
        {
            List<double> numbers = new List<double>();

            foreach (string numberString in input)
            {
                if (double.TryParse(numberString, out double number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
        }

        /// Calculates statistics for a list of valid numbers.
        private void CalculateStatistics(List<double> numbers)
        {
            if (numbers.Count == 0)
            {
                return;
            }

            NumberCount = numbers.Count;
            Total = numbers.Sum();
            Average = numbers.Average();
            Maximum = numbers.Max();
            Minimum = numbers.Min();
        }
    }
}
