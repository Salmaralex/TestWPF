using MVVM2.Infrustructure;
using MVVM2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM2.ViewsModels
{
   public class AboutViewModel : BasePropertyChange
    {
        private Currensy currentCurrency;
        public Currensy CurrentCurrency

        {
            get => currentCurrency;
            set
            {
                currentCurrency = value;
                NotifyOfPropertyChanged();
            }

        }

        public AboutViewModel(Currensy currensy)
        {
            CurrentCurrency= currensy;
        }
    }
}
