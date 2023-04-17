using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MVVM2.Infrustructure;
using MVVM2.Views;

namespace MVVM2.ViewsModels
{
   public class MainViewModel:BasePropertyChange
	{ 
		private APIViewModel apiViewModel;
		private UserControl currentPage;
		public UserControl CurrentPage
		{
			get  => currentPage; 
			set 
			{ 
				currentPage = value;
				NotifyOfPropertyChanged();
			}
		}

		public ICommand ShowMainPage { get; set; }
		public ICommand ShowSecond { get; set; }


		private void SwitchView(UserControl userControl)
        {
			if (userControl == null) return;
			CurrentPage = userControl;
		}
		
		public MainViewModel()
		{
			apiViewModel= new APIViewModel();
			apiViewModel.SwitchView += SwitchView;

			ShowMainPage = new RelayComand(x =>
			{
				CurrentPage = new APIViewPage(apiViewModel);
			});


		}
	}
}
