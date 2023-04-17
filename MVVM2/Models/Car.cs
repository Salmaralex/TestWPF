using MVVM2.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM2.Models
{
    class Car:BasePropertyChange
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImageURL { get; set; }
    }
}
