using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class Activity : IComparable<Activity>
    {
        public string Title { get; set; }
        private string Description { get; set; }
        public decimal Cost { get; set; }

        public DateTime ActivityDate { get; set; }

        public enum ActivityType
        {
            Air,
            Water,
            Land
        }

        public ActivityType? TypeOfActivity { get; set; }

        public Activity(string title, string description, decimal cost, DateTime date, ActivityType? type)
        {
            Title = title;
            Description = description;
            Cost = cost;
            ActivityDate = date;
            TypeOfActivity = type;
        }

        public override string ToString()
        {
            return $"{Title} - {ActivityDate.ToShortDateString()}";
        }


        /// <summary>
        /// Compares activity instances against eachother using date
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Activity other)
        {
            // Alphabetic sort if salary is equal. [A to Z]
            if (this.ActivityDate == other.ActivityDate)
            {
                return this.ActivityDate.CompareTo(other.ActivityDate);
            }
            // Default to date sort. [High to low]
            return other.ActivityDate.CompareTo(this.ActivityDate);
        }


    }
}
