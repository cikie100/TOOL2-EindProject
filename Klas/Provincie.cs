using System;
using System.Collections.Generic;
using System.Text;

namespace Tool2.Klas
{
    public class Provincie
    {
        public String provincieId { get; set; }
        public String provincieNaam { get; set; }
        public String taalCodeProvincieNaam { get; set; }
        public List<String> gemeenteIdStrings { get; set; }

        public Provincie(String provincieId, string provincieNaam,string taalCodeProvincieNaam )
        {
            this.provincieId = provincieId;
            this.taalCodeProvincieNaam = taalCodeProvincieNaam;
            this.provincieNaam = provincieNaam;

            this.gemeenteIdStrings = new List<string>();

        }

        public override bool Equals(object obj)
        {
            return obj is Provincie provincie &&
                   provincieId == provincie.provincieId;
        }
    }
}
