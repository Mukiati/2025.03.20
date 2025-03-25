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

namespace _2025._03._20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        serverconnection connection;
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            connection = new serverconnection("http://127.1.1.1:3000");
        }
       async void Loginclick(object s ,EventArgs e)
        {
            bool valami = await connection.Login(usernameinput.Text, passwordinput.Password);

            if (valami)
            {
                MessageBox.Show("sikeres bejeletnkezés");
                afterlogin a = new afterlogin(connection) { Top = this.Top, Left = this.Left, Visibility = Visibility.Visible};
                this.Hide();
                a.Closing += (ss, ee) =>
                {
                    this.Show();
                };

            }
        }
        async void Regclick(object s, EventArgs e)
        {
            bool valami = await connection.Reg(usernameinput.Text, passwordinput.Password);

            if (valami)
            {
                MessageBox.Show("sikeres regisztráció");
                

            }
        }


    }
}
