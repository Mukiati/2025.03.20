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
        }
        async void Start()
        {
           
            List<string> all = await connection.Profiles();
            foreach (string  item in all)
            {
                lista.Children.Add(new TextBlock() {Text = item});
            }
        }
    }
}
