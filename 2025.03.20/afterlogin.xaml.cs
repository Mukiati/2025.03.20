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
using System.Windows.Shapes;

namespace _2025._03._20
{
    /// <summary>
    /// Interaction logic for afterlogin.xaml
    /// </summary>
    public partial class afterlogin : Window
    {
        serverConnection connection;
        
       

        public afterlogin(serverConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            start();
            
            asd();
        }
        async void start()
        {
            List<string> all = await connection.Profiles();
            foreach (string item in all)
            {
                alls.Children.Add(new TextBlock() { Text = item });
            }
        }
        async void create(object s, EventArgs e)
        {
            bool temp = await connection.createPerson(NameInput.Text, Convert.ToInt32(AgeInput.Text));
            if (temp)
            {
                loadPersons();
                MessageBox.Show("Sikeres létrehozás");
            }
        }
       

        async void deleteAll(object s, EventArgs e)
        {
            bool temp = await connection.deleteAllPerson();
            if (temp)
            {
                loadPersons();
                MessageBox.Show("Sikeres törlés");
            }
        }

        string oldname;

        async void loadPersons()
        {
           

            NameStackPanel.Children.Clear();
            AgeStackPanel.Children.Clear();
            dels.Children.Clear();
            szr.Children.Clear();
            List<string> allnames = await connection.AllNames();
           
            for (int i = 0; i < allnames.Count; i++)
            {
                oldname = allnames[i];
            }
            foreach (string item in allnames)
            {
               
                TextBlock nameLabel = new TextBlock();
                nameLabel.Text = item;
                NameStackPanel.Children.Add(nameLabel);
                Button delbutton = new Button();
                delbutton.Content = "X";
                Button modify = new Button();
                modify.Content = "szerk";
                modify.Click += (s, e) =>
                {
                    
                    szerk.IsEnabled = true;
                    NameInput.Text = item;
                    


                };
                modify.Click += (s, e) =>
                {
                    
                    szerk.IsEnabled = true;

                    

                };

                delbutton.Click += async (s, e) =>
                {
                    bool temp = await connection.deletePerson(nameLabel.Text);
                    if (temp)
                    {
                        loadPersons();
                        MessageBox.Show("Sikeres törlés!");
                    }
                };
                dels.Children.Add(delbutton);
                //System.ArgumentException: 'A megadott Visual elem már gyermeke egy másik Visual elemnek, vagy egy CompositionTarget
                szr.Children.Add(modify);

            }
            List<string> allages = await connection.AllAges();
            foreach (string item in allages)
            {
                AgeStackPanel.Children.Add(new TextBlock() { Text = item });
               
                
               
            }
        }
        void asd()
        {
           
            szerk.IsEnabled = true;
            szerk.Click += async (ss, ee) =>
            {
                


                bool temp = await connection.Upddate(NameInput.Text, oldname,Convert.ToInt32(AgeInput.Text));
                if (temp)
                {
                    loadPersons();
                    MessageBox.Show("Sikeres módosítás");
                }
            };
        }

    }
}
