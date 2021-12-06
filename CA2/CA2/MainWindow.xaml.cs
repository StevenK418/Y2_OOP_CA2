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
            //Iterate through the activity types disctionary
            foreach (var activityType in activityTypes)
            {
                //Create a new instance of the activity class
                Activity activity = new Activity(activityType.Key, activityType.Value, 10.0m, new DateTime(2015, 12, 25), GetCategory(activityType.Key));
                //Add this new instance to the activities collection
                activities.Add(activity);
            }

            //Call the sort method on the activities collection
            activities.Sort();

            //Set the souce of the listbox to the activities collection
            SetListBoxSource(lstbx_all, activities);
            //lstbx_all.ItemsSource = activities;

            //Call the sort method on the selected activities collection
            selectedActivities.Sort();

            //Set the souce of the listbox to the selected activities collection
            SetListBoxSource(lstbx_selected, selectedActivities.ToList<Activity>());
            //lstbx_selected.ItemsSource = selectedActivities;

            //Update the total cost field
            UpdateTotalCost(activities.ToList<Activity>());
        }

        private void lstbx_all_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDescriptionField(lstbx_all);
        }

        private void btn_forward_Click(object sender, RoutedEventArgs e)
        {
            //Move the item from the all listbox to the selected listbox
            MoveItem(lstbx_all, activities, selectedActivities);
        }

        private void btn_backward_Click(object sender, RoutedEventArgs e)
        {
            MoveItem(lstbx_selected, selectedActivities, activities);
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
                //If the select item contains the activity title 
                if (box.SelectedItem.ToString().Contains(activity.Title))
                {
                    //Add the matching activity from the collection to the selected activities collection
                    destination.Add(activity);

                    //Store the activity for removal later
                    activityToRemove = activity;
                }
            }

            //Remove the activity from the original collection
            location.Remove(activityToRemove);

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
            foreach (Activity activity in activities)
            {
                totalCost += activity.Cost;
            }

            tblk_totalCost.Text = $"€{totalCost}";
        }

        /// <summary>
        /// Changes the view of the Listbox to activities matching a given category type.
        /// </summary>
        /// <param name="category"></param>
        private void ChangeView(string category)
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
          
            //Update the total cost field to the current total for activities shown
            UpdateTotalCost(categorizedActivities);
        }

        private void radioButton_Selected(object sender, RoutedEventArgs e)
        {
            //Retrieve and store the checked radio button sending the event
            RadioButton radioButton = (RadioButton)sender;

            //Check the radio button that's selected
            if (radioButton == rdbtn_Land)
            {
                ChangeView("Land");
            }
            else if (radioButton == rdbtn_water)
            {
                ChangeView("Water");
            }
            else if (radioButton == rdbtn_Air)
            {
                ChangeView("Air");
            }
            else
            {
                ChangeView("All");
            }
        }
    }
}
