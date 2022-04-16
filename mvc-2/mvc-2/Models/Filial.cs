using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_2.Models
{
    public class Filial
    {
        public int ItemId { get; set; }
        public string Ad { get; set; }
        public int FilialId { get; set; }
        public string FilialAd { get; set; }
        public List<Filiallar> Filiallar { get; set; }
        public int Say { get; set; }
    }
}
