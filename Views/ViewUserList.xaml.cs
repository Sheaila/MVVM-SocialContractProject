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

namespace MVVM_SocialContractProject.Views
{
    /// <summary>
    /// Interaction logic for ViewUserList.xaml
    /// </summary>
    public partial class ViewUserList : UserControl
    {
        public ViewUserList()
        {
            InitializeComponent();
        }

        private void CreateUser_MouseEnter(object sender, MouseEventArgs e)
        {
            CreateUser.Opacity = 0.9;
        }

        private void CreateUser_MouseLeave(object sender, MouseEventArgs e)
        {
            CreateUser.Opacity = 0.9;
        }
    }
}
