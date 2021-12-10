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

        /// <summary>
        /// Parametrised constructor - used to initialize all properties on each object instantiation
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        /// <param name="date"></param>
        /// <param name="type"></param>
        public Activity(string title, string description, decimal cost, DateTime date, ActivityType? type)
        {
            Title = title;
            Description = description;
            Cost = cost;
            ActivityDate = date;
            TypeOfActivity = type;
        }

        /// <summary>
        /// Overrides the ToString() method of the parent Object Class
        /// </summary>
        /// <returns>Returns a formatted string of the ActivityTitle and Date</returns>
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
            // Sort Alphabetically if date is equal.
            if (this.ActivityDate == other.ActivityDate)
            {
                return this.ActivityDate.CompareTo(other.ActivityDate);
            }
            // Otherwise sort by date as default.
            return other.ActivityDate.CompareTo(this.ActivityDate);
        }
    }
}
