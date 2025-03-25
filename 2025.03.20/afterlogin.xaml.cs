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
        serverconnection connection;
       
        public afterlogin(serverconnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            Start();
            Start2();
            Start3();
        }
        async void Start()
        {

            List<string> all = await connection.Profiles();
            foreach (string item in all)
            {
                lista.Children.Add(new TextBlock() { Text = item });
            }
        }
        async void Regnew(object s, EventArgs e)
        {
            bool valami = await connection.Reg2(nameinputt.Text, Convert.ToInt32(ageinputt.Text));
            if (valami)
            {
                MessageBox.Show("Registered in");
            }
        }
       
        async void Start2()
        {
            List<string> allnames = await connection.Names();
            foreach (string item in allnames)
            {
                
                namelista.Children.Add(new TextBlock() { Text = item });

            }
        }
        async void Start3()
        {
            


            List<int> allages = await connection.Ages();
            foreach (int item in allages)
            {
                
                
                agelista.Children.Add(new TextBlock() { Text = item.ToString() });
                Button delete = new Button();
                delete.Content = "X";

                delete.Width = 15;
                delete.Height = 15;
                agelista.Children.Add(delete);
            }
        }

    }
}
