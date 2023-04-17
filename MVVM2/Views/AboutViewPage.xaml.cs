using MVVM2.Models;
using MVVM2.ViewsModels;
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

namespace MVVM2.Views
{
    /// <summary>
    /// Interaction logic for AboutViewPage.xaml
    /// </summary>
    public partial class AboutViewPage : UserControl
    {
        public AboutViewPage(AboutViewModel aboutViewModel,Currensy currensy)
        {
            InitializeComponent();
            DataContext = aboutViewModel;
            this.DataContext = new AboutViewModel(currensy);
        }
    }
}
