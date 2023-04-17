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
    /// Interaction logic for APIViewPage.xaml
    /// </summary>
    public partial class APIViewPage : UserControl
    {
        public APIViewPage(APIViewModel aPIView)
        {
            DataContext = aPIView;
            InitializeComponent();
        }
    }
}
