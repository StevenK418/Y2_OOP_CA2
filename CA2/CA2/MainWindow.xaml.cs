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

        ObservableCollection<Activity> activities = new ObservableCollection<Activity>();
        ObservableCollection<Activity> selectedActivities = new ObservableCollection<Activity>();
        
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
                Activity activity = new Activity(activityType.Key, activityType.Value, 10.0m, new DateTime(2015, 12, 25));
                //Add this new instance to the activities collection
                activities.Add(activity);
            }

            //Set the souce of the listbox to the activities collection
            lstbx_all.ItemsSource = activities;
        }

        private void lstbx_all_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Cycle through Dictionary
            foreach (var activity in activityTypes)
            {
                //If the selected item contains a key in the dictionary
                if (lstbx_all.SelectedItem.ToString().Contains(activity.Key))
                {
                    //Set the description field to the associated value in the dictionary
                    tblk_description.Text = activity.Value;
                }
            }
        }

        private void btn_forward_Click(object sender, RoutedEventArgs e)
        {
            foreach (var activity in activities)
            {
               
            }
        }
    }
}
