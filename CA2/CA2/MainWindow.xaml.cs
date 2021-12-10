/*
 * Name:                Steven Kelly
 * Date:                10/12/2021
 * Lab:                 CA2
 * Description:         "Activity Planner"
 * Developer note:      "Price of each individual selected activity can be viewed by selecting individual 
 *                      item in the selected box". Instead of implemented an additional button, the total cost value can be viewed again by selecting 
 *                      an item in the All activities box. 
 * Github: 
 *                      Clone: "https://github.com/StevenK418/Y2_OOP_CA2.git"
 *                      View Online: "https://github.com/StevenK418/Y2_OOP_CA2"
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> activityTypes = new Dictionary<string, string>()
        {
            {"Treking", "A full day trekking the Highlands with mountainside lunch provided"},
            {"Kayaking", "Half day lakeland kayak with island picnic."},
            {"Parachuting", "Parachute 100 feet above snowden in an exciting airbourne adventure like never before."},
            {"Mountain Biking", "Explore the road less travelled by bike across the Yorkshire Dales."},
            {"Surfing", "Ride the waves in a thrilling, ocean adventure off Ireland's Atlantic coast."},
            {"Hang Gliding", "Hover above the alps in a breath-taking, cloud-based trip of a lifetime."},
            {"Abseiling", "Reach new heights by climbing the cliffs of Moher on Irelan's West Coast."},
            {"Sailing", "Anchor's away in this sea-faring adventure off Ireland's South West Coast."},
            {"Helicopter Tour", "Explore Ireland's East coast from above Wicklow's wonderous coast."}
        };

        Dictionary<string, Activity.ActivityType> activityCategories = new Dictionary<string, Activity.ActivityType>()
        {
            {"Treking", Activity.ActivityType.Land},
            {"Kayaking", Activity.ActivityType.Water},
            {"Parachuting", Activity.ActivityType.Air},
            {"Mountain Biking", Activity.ActivityType.Land},
            {"Surfing", Activity.ActivityType.Water},
            {"Hang Gliding", Activity.ActivityType.Air},
            {"Abseiling", Activity.ActivityType.Air},
            {"Sailing", Activity.ActivityType.Water},
            {"Helicopter Tour", Activity.ActivityType.Air}
        };

        List<Activity> activities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Declare new random object to pass to date generate method
            Random rnd = new Random();

            //Iterate through the activity types disctionary
            foreach (var activityType in activityTypes)
            {
                //Create a new instance of the activity class
                Activity activity = new Activity(activityType.Key, activityType.Value, GenerateRandomCost(rnd), GenerateRandomDate(rnd), GetCategory(activityType.Key));
                //Add this new instance to the activities collection
                activities.Add(activity);
            }

            //Call the sort method on the activities collection
            activities.Sort();

            //Set the souce of the listbox to the activities collection
            SetListBoxSource(lstbx_all, activities);

            //Call the sort method on the selected activities collection
            selectedActivities.Sort();

            //Set the souce of the listbox to the selected activities collection
            SetListBoxSource(lstbx_selected, selectedActivities.ToList<Activity>());

            //Update the total cost field on initialization
            UpdateTotalCost(selectedActivities);
        }

        private void lstbx_all_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear any error messages from the message box
            ClearMessageText();

            //Ensure the selected item is not null before continuing
            if (lstbx_all.SelectedItem != null)
            {
                //Update the description field
                UpdateDescriptionField(lstbx_all);
            }

            //Update the running total of the selected activities.
            UpdateTotalCost(selectedActivities);
        }

        private void btn_forward_Click(object sender, RoutedEventArgs e)
        {
            if (lstbx_all.SelectedItem != null)
            {
                //Clear any error messages from the message box
                ClearMessageText();

                //Move the item from the all listbox to the selected listbox
                MoveItem(lstbx_all, activities, selectedActivities);
            }
            else
            {
                //Show an error message
                ShowMessage("Error: No Activity Selected!");
            }
        }

        private void lstbx_selected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear any error messages from the message box
            ClearMessageText();

            //Ensure the selected item is not null before continuing
            if (lstbx_selected.SelectedItem != null)
            {
                //Update the description field
                UpdateDescriptionField(lstbx_selected);

                //Get a reference to the object selected in the box
                Activity activity =  lstbx_selected.SelectedItem as Activity;

                //Update the total cost field to the cost of this selected activity object
                UpdateTotalCost(activity.Cost);
            }
            else
            {
                //Update the total cost field to the cost of total selected activities
                UpdateTotalCost(selectedActivities);
            }
        }

        private void radioButton_Selected(object sender, RoutedEventArgs e)
        {
            //Retrieve and store the checked radio button sending the event
            RadioButton radioButton = (RadioButton)sender;

            //Check the radio button that's selected
            if (radioButton == rdbtn_Land)
            {
                FilterView("Land");
            }
            else if (radioButton == rdbtn_water)
            {
                FilterView("Water");
            }
            else if (radioButton == rdbtn_Air)
            {
                FilterView("Air");
            }
            else
            {
                FilterView("All");
            }
        }

        private void btn_backward_Click(object sender, RoutedEventArgs e)
        {
            if (lstbx_selected.SelectedItem != null)
            {
                //Clear any error messages from the message box
                ClearMessageText();
                //Move the item
                MoveItem(lstbx_selected, selectedActivities, activities);
            }
            else
            {
                //if nothing selected, show an error message
                ShowMessage("Error: No Activity Selected!");
            }
        }

        /// <summary>
        /// Displayes a given message via the messages textblock
        /// </summary>
        /// <param name="message"></param>
        private void ShowMessage(string message)
        {
            //Set the text of the message
            tblk_messages.Text = message;
            //Set the colour of the text
            tblk_messages.Foreground = Brushes.Red;
        }

        //Clears the message box text
        private void ClearMessageText()
        {
            tblk_messages.Text = "";
        }

        /// <summary>
        /// Moves a selected item from a given listbox to another
        /// </summary>
        /// <param name="box"></param>
        /// <param name="location"></param>
        /// <param name="destination"></param>
        private void MoveItem(ListBox box, List<Activity> location, List<Activity> destination)
        {
            //Declare a variable to store activity for removal
            Activity activityToRemove = null;

            //Cycle through activities list
            foreach (Activity activity in location)
            {
                if(box.SelectedItem != null)
                {
                    //If the select item contains the activity title 
                    if (box.SelectedItem.ToString().Contains(activity.Title))
                    {
                        //Add the matching activity from the collection to the selected activities collection
                        destination.Add(activity);

                        //Sort the destination on each add
                        destination.Sort();

                        //Store the activity for removal later
                        activityToRemove = activity;
                    }
                }
            }

            //Remove the activity from the original collection
            location.Remove(activityToRemove);

            //Update total cost of currently selected items
            UpdateTotalCost(selectedActivities);

            //Sever the connection between the boxes and the sources prior to refresh
            SetListBoxSource(lstbx_all, null);
            SetListBoxSource(lstbx_selected, null);

            //Update the itemsource for both boxes to refresh data displayed
            SetListBoxSource(lstbx_all, activities);
            SetListBoxSource(lstbx_selected, selectedActivities);
        }

        /// <summary>
        /// Updates the description field to the activity's associated description 
        /// </summary>
        /// <param name="box"></param>
        private void UpdateDescriptionField(ListBox box)
        {
            //Check if the selected item is null (after removal) before doing anything
            if (box.SelectedItem != null)
            {
                //Cycle through Dictionary
                foreach (var activity in activityTypes)
                {
                    //If the selected item contains a key in the dictionary
                    if (box.SelectedItem.ToString().Contains(activity.Key))
                    {
                        //Set the description field to the associated value in the dictionary
                        tblk_description.Text = activity.Value;
                    }
                }
            }
        }

        /// <summary>
        /// Searches for a given activity by name.
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns>Returns the relevant activity category as an enum.</returns>
        private Activity.ActivityType? GetCategory(string activityName)
        {
            Activity.ActivityType? activityType = null;
            foreach (var type in activityCategories)
            {
                if(type.Key == activityName)
                {
                    activityType = type.Value;
                }
            }
            return activityType;
        }

        /// <summary>
        /// Changes the source of a given listbox to a given collection
        /// </summary>
        /// <param name="box"></param>
        /// <param name="source"></param>
        private void SetListBoxSource(ListBox box, List<Activity> source)
        {
            box.ItemsSource = source;
        }

        /// <summary>
        /// Updates 
        /// </summary>
        /// <param name="activities"></param>
        private void UpdateTotalCost(List<Activity> activities)
        {
            decimal totalCost = 0m;
            if(activities.Count > 0)
            {
                //Iterate through the list passed
                foreach (Activity activity in activities)
                {
                    //Accumulate and store the cost of all items
                    totalCost += activity.Cost;
                }
            }
            // Set the totalCost field to the result
            tblk_totalCost.Text = $"€{totalCost}";
        }

        /// <summary>
        /// Overloaded variation of the above method. Instead of taking a list, 
        /// takes a single value. 9+
        /// </summary>
        /// <param name="cost"></param>
        private void UpdateTotalCost(decimal cost)
        {
            tblk_totalCost.Text = $"€{cost}";
        }

        /// <summary>
        /// Changes the view of the Listbox to activities matching a given category type.
        /// </summary>
        /// <param name="category"></param>
        private void FilterView(string category)
        {
            List<Activity> categorizedActivities = new List<Activity>();

            //Iterate through activities collection
            foreach (Activity activity in activities)
            {
                //If the activity has the type specified, add it to the new List
                if (activity.TypeOfActivity.ToString() == category)
                {
                    categorizedActivities.Add(activity);
                }
                else if(category == "All")
                {
                    //Otherwise, if All is selected, add each activity to the list
                    categorizedActivities.Add(activity);
                }
            }

            //Set the source of the listbox to the new List
            SetListBoxSource(lstbx_all, categorizedActivities);
        }

        /// <summary>
        /// Generates a new random DatTime object
        /// </summary>
        /// <returns>Returns the randomly generated datetime object.</returns>
        private DateTime GenerateRandomDate(Random rnd)
        {
            //Create a new start date for the range min
            DateTime startDate = new DateTime(2019, 1, 1);

            //Define the end date for the range max
            DateTime endDate = DateTime.Today;

            //Create a new range based on days between today and the start date
            int range = (endDate - startDate).Days;

            //Add a random number of days between today and the startdate to the startdate
            DateTime result = startDate.AddDays(rnd.Next(range));

            //Return the result
            return result;
        }

        /// <summary>
        /// Generate a random cost.
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Returns the cost as a decimal.</returns>
        private decimal GenerateRandomCost(Random random)
        {
            //Declare new decimal to store resulting cost
            decimal cost = 0m;

            //Generate the integral part of the cost
            int wholePart = random.Next(0, 500);
            //Generate the fractional part of the cost
            int fractionalPart = random.Next(0, 100);

            //Create a string by concatenating both values with a decimal point between
            string value = $"{wholePart}.{fractionalPart}";

            //Parse this string as a decimal and store in cost
            cost = decimal.Parse(value);

            //Return the cost
            return cost;
        }
    }
}
