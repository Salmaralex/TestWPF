using MVVM2.Infrustructure;
using MVVM2.Models;
using MVVM2.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;


namespace MVVM2.ViewsModels
{
    public class APIViewModel: BasePropertyChange
    {
        public ICommand GetCurreencyesCommand { get; set; }
        public ICommand ShowAboutPageCommand { get; set; }
        public ICommand SortByNameCommand { get; set; }
        public ICommand SortByPriceUsdCommand { get; set; }
        public ICommand FilterTextChangedCommand { get; set; }

        private AboutViewModel aboutViewModel;



        UserControl currentPage;
        public UserControl CurrentPage
        {
            get => currentPage; 
            set
            {
                currentPage = value;
                NotifyOfPropertyChanged();

            }
        }

        ObservableCollection<Currensy> currensies { get; set; }
       

        public ObservableCollection<Currensy> Currensies
        {
            get => currensies;
            set
            {
                currensies = value;
                NotifyOfPropertyChanged();
            }

        }

        Currensy selectedCurrensy;

        public Currensy SelectedCurrensy
        {
            get => selectedCurrensy;
            set
            {
                selectedCurrensy = value;
                NotifyOfPropertyChanged();
            }
        }
        public event Action<UserControl> SwitchView;
        public APIViewModel()
        {
            aboutViewModel = new AboutViewModel(SelectedCurrensy);
            FilterTextChangedCommand = new RelayComand(str =>
            {
                if (Currensies.Count > 0)
                {
                    Currensies = new ObservableCollection<Currensy>(Currensies.
                        Where(x => x.Name.Contains(str.ToString())
                        || x.Name.StartsWith(str.ToString())
                        || x.Name.EndsWith(str.ToString())));
                }
            });
            ShowAboutPageCommand = new RelayComand(x =>
            {
                SwitchView?.Invoke(new AboutViewPage(aboutViewModel, SelectedCurrensy));
            });

            SortByNameCommand = new RelayComand(x =>
            {
                if (Currensies.Count > 0)
                {
                    var collection = Currensies.ToList();
                    var sorted = collection.OrderBy(y => y.Name).ToList();
                    Currensies = new ObservableCollection<Currensy>(sorted);
                }
            });
            SortByPriceUsdCommand = new RelayComand(x =>
            {
                if (Currensies.Count > 0)
                {
                    var collection = Currensies.ToList();
                    var sorted = collection.OrderBy(y => y.PriceUsd).Reverse().ToList();
                    Currensies = new ObservableCollection<Currensy>(sorted);
                }
            });

            GetCurreencyesCommand =  new RelayComand(async x  =>
             {

                 HttpClient httpClient = new HttpClient();
                 var res =  await httpClient.GetAsync("https://api.coincap.io/v2/assets");
                 if (res.IsSuccessStatusCode)
                 {
                     var json = await res.Content.ReadAsStringAsync();
                     JObject o = JObject.Parse(json);
                     JArray data = (JArray)o["data"];
                     var currensies = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Currensy>>(data.ToString()).ToList();
                     Currensies = new ObservableCollection<Currensy>(currensies.Take(10));
                 }
             });
        }
    }
}
