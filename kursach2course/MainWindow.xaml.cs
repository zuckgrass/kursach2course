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
using DataControl;

namespace kursach2course
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            FaceControlledClub Prime_Facecontrol = new FaceControlledClub();
            string name = nametext.Text;
            bool member = selector.Text == "Yes";
            Man m = new Man() { name = name, isMember = member};
            if(Prime_Facecontrol.Enter_Club(m))
            {
                EnteringWindow mw = new EnteringWindow();
                Hide();
                mw.Show();
            }
            else
            {
                RegistrationWindow mw = new RegistrationWindow();
                Hide();
                mw.Show();
            }
        }
    }
    class Man
    {
        public string name;
        public bool isMember;
    }

    //interface
    abstract class Abst_Club
    {
        public abstract bool Enter_Club(Man m);
    }

    //realsubject
    class Club : Abst_Club
    {
        public override bool Enter_Club(Man m)
        {
            MessageBox.Show($"Welcome to our club, {m.name}");
            return true;
        }
    }
    //proxy
    class FaceControlledClub : Abst_Club
    {
        Club club = new Club();

        public override bool Enter_Club(Man m)
        {
            if (m.isMember)
            {
                club.Enter_Club(m);
                return true;
            }
            else
            {
                MessageBox.Show("Please register");
                return false;
            }
                
        }
    }

}
