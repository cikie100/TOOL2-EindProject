using System;
using System.Collections.Generic;
using System.Text;

namespace Tool2.Klas
{
   public class Gemeente
    {
        public string gemeenteId { get; set; }
        public string gemeenteNaam { get; set; }
        public List<String> stratenNaamId { get; set; }

        public Gemeente(string gemeenteId, string gemeenteNaam)
        {
           
            this.gemeenteId = gemeenteId;
            this.gemeenteNaam = gemeenteNaam;

            
            stratenNaamId = new List<string>();
        }

    }


}
