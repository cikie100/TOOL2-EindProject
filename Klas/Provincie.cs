using System;
using System.Collections.Generic;
using System.Text;

namespace Tool2.Klas
{
    public class Provincie
    {
        public int ProvincieId { get; set; }
        public String ProvincieNaam { get; set; }
        public String TaalCodeProvincieNaam { get; set; }
        public List<int> GemeenteIdStrings { get; set; }

        public Provincie(int provincieId, string provincieNaam,string taalCodeProvincieNaam )
        {
            this.ProvincieId = provincieId;
            this.TaalCodeProvincieNaam = taalCodeProvincieNaam;
            this.ProvincieNaam = provincieNaam;

            this.GemeenteIdStrings = new List<int>();

        }

        public override bool Equals(object obj)
        {
            return obj is Provincie provincie &&
                   ProvincieId == provincie.ProvincieId &&
                   ProvincieNaam == provincie.ProvincieNaam &&
                   TaalCodeProvincieNaam == provincie.TaalCodeProvincieNaam &&
                   EqualityComparer<List<int>>.Default.Equals(GemeenteIdStrings, provincie.GemeenteIdStrings);
        }
    }
}
