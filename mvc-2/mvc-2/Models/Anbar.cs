using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_2.Models
{
    public class Anbar
    {
        public int? ItemId { get; set; }
        [Required(ErrorMessage = "Ad daxil olunmalıdır!")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Daxili Kod daxil olunmalıdır!")]
        public string Daxili_Kod { get; set; }
        [Required(ErrorMessage = "Xarici Kod daxil olunmalıdır!")]
        public string Xarici_Kod { get; set; }

        public int NovId { get; set; }
        
        public string NovAd { get; set; }
     

        public int OlkeId { get; set; }
    
        public string OlkeAd { get; set; }
        [Required(ErrorMessage = "Say daxil olunmalıdır!")]
        public int Say { get; set; }
        [Range(0,10000)]
        public int Topdan_Satis_Qiymeti { get; set; }
        public List<Olke> Olkeler { get; set; }
        public List<Nov> Novler { get; set; }
        




    }
}
