using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Globalization;

namespace Lab1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string Number1 { get; set; }

        [BindProperty]
        public string Number2 { get; set; }

        [BindProperty]
        public string Number3 { get; set; }

        public bool ShowStatistics { get; set; }
        public bool ShowErrorMessage { get; set; }
        public int NumberCount { get; set; }
        public double Maximum { get; set; }
        public double Minimum { get; set; }
        public double Total { get; set; }
        public double Average { get; set; }

        public void OnPost()
        {
            ShowStatistics = false;
            ShowErrorMessage = false;
            NumberCount = 0;
            Total = 0;
            Average = 0;
            
            List<string> numbers = new List<string> { Number1, Number2, Number3 };

            CalculateStatistics(numbers);

            if (NumberCount > 0)
            {
                ShowStatistics = true;
            }
            else
            {
                ShowErrorMessage = true;
            }
        }

        private void CalculateStatistics(List<string> input)
        {
            List<double> numbers = new List<double>();

            foreach (string numberString in input)
            {
                if (double.TryParse(numberString, out double number))
                {
                    numbers.Add(number);
                }
            }

            if (numbers.Count != 0)
            {
                NumberCount = numbers.Count;
                Total = numbers.Sum();
                Average = numbers.Average();
                Maximum = numbers.Max();
                Minimum = numbers.Min();
            }

        }
    }
}
