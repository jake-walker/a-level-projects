using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace WpfApplication4
{
    // <summary>
    // Interaction logic for MainWindow.xaml
    // </summary>
    public partial class MainWindow
    {
        // This declares a public array of Person Objects called customers
        // TASK 0 (Done)
        // If you want, you could rewrite this as a list

        public List<Person> Customers = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // This is the event that fires when you click this button
        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            // This "instantiates" three instances of Person objects by overloading the constructor
            var david = new Person(1, "David", "Golf", "M", Convert.ToDateTime("05/08/1980"));
            var fred = new Person(2, "Fred", "Music", "M", Convert.ToDateTime("10/12/2010"));
            var tom = new Person(3, "Tom", "Billiards", "M", Convert.ToDateTime("10/01/2012"));

            // Then adds them to the array of Objects
            // Customers[0] = David;
            // Customers[1] = Fred;
            // Customers[2] = Tom;
            Customers.Add(david);
            Customers.Add(fred);
            Customers.Add(tom);

            // TASK 1
            // Add 3 more people to the array of objects

            Customers.Add(new Person(4, "Bob", "Computing", "M", Convert.ToDateTime("06/07/2008")));
            Customers.Add(new Person(4, "Sam", "Anime", "M", Convert.ToDateTime("05/12/2001")));
            Customers.Add(new Person(4, "Will", "Roleplay", "M", Convert.ToDateTime("05/12/2001")));


            // For all the objects in the array
            foreach (var t in Customers)
            {
                // ping their names into a message box
                MessageBox.Show(t.GetName());
                // add them to a listbox
                listBox.Items.Add(t.GetName());
                // TASK 2
                // Add them to the ComboBox cboCustomers too
                cboCustomers.Items.Add(t.GetName());
            }
        }

        private void btnImportCSV_Click(object sender, RoutedEventArgs e)
        {
            // TASK 3
            // This code fires when you click an "Import" button
            // Get it to read data from a .csv file using streamreader in c# and import it into the Customer array
            // Clear the data in the listbox
            // Add this new data instead to the listbox

            var dialog = new OpenFileDialog
            {
                Filter = "CSV|*.csv",
                Title = "Open a CSV file to import...",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (dialog.ShowDialog() == true)
            {
                var path = dialog.FileName;

                Customers.Clear();
                listBox.Items.Clear();

                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line == null) continue;
                        var values = line.Split(',');

                        var customer = new Person(int.Parse(values[0]), values[1], values[2], values[3],
                            Convert.ToDateTime(values[4]));

                        Customers.Add(customer);
                        listBox.Items.Add(customer.GetName());
                    }
                }
            }
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            // TASK 4
            // When you click on this button it tells you how many Customers there are in the Array
            // And displays the answer in a MessageBox
            // Would you also get it to count the number of sly foxes in the room and display this in a MessageBox
            var rand = new Random();

            MessageBox.Show($"There are {Customers.Count} customer(s) and {rand.Next(1, 10)} sly foxes.");
        }
    }
}

public class Person
    // This declares a public object "Person"
    // With some getters and setters, as object properties cannot be accessed directly 
{
    private DateTime _dob; // DOB 
    private string _gender; // Person gender
    private int _id; // Person ID Number
    private string _interests; // Person interests
    private string _name; // Person Name

    public Person(int id, string name, string interests, string gender, DateTime dob)
    {
        // constructor with overloads
        SetId(id);
        SetName(name);
        SetInterests(interests);
        SetGender(gender);
        SetDob(dob);
    }

    public void SetId(int i)
    {
        _id = i;
    }

    public int GetId()
    {
        return _id;
    }

    public void SetName(string n)
    {
        _name = n;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetInterests(string i)
    {
        _interests = i;
    }

    public string GetInterests()
    {
        return _interests;
    }

    public void SetGender(string g)
    {
        _gender = g;
    }

    public string GetGender()
    {
        return _gender;
    }

    public void SetDob(DateTime d)
    {
        _dob = d;
    }

    public DateTime GetDob()
    {
        return _dob;
    }

    // TASK 5
    // Write a method "GetAge" that calculates the age from a DoB
    // Then instead of displaying just the name in the listbox / combo box, get it to display the Name and Age side by side
    public int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - _dob.Year;
        if (_dob > today.AddYears(-age)) age--;
        return age;
    }
}