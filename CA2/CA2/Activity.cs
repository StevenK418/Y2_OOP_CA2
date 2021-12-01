using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{


    class Activity
    {
        private string Title { get; set; }
        private string Description { get; set; }
        private decimal Cost { get; set; }

        public DateTime Date { get; set; }

        public Activity(string title, string description, decimal cost, DateTime date)
        {
            Title = title;
            Description = description;
            Cost = cost;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Title} - {Date.ToShortDateString()}";
        }


    }
}
