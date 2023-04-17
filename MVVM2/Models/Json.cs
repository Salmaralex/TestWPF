using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM2.Models
{
   static class Json
    {


      static  public void Serialize(string path, List<Car> list) {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);

            File.WriteAllText(path, json);

        }
      static  public ObservableCollection<Car> DeSerialize(string path, ObservableCollection<Car> list) {
            string json = File.ReadAllText(path);
            ObservableCollection<Car> tmp= JsonConvert.DeserializeObject<ObservableCollection<Car>>(json);
           return tmp;
        }
    }
}
