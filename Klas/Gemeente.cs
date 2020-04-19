using System.Collections.Generic;

namespace Tool2.Klas
{
    public class Gemeente
    {
        public int GemeenteId { get; set; }
        public string GemeenteNaam { get; set; }
        public List<int> StratenNaamIdLijst { get; set; }

        public Gemeente(int gemeenteId, string gemeenteNaam)
        {
            this.GemeenteId = gemeenteId;
            this.GemeenteNaam = gemeenteNaam;

            StratenNaamIdLijst = new List<int>();
        }

        public override bool Equals(object obj)
        {
            return obj is Gemeente gemeente &&
                   GemeenteId == gemeente.GemeenteId &&
                   GemeenteNaam == gemeente.GemeenteNaam &&
                   EqualityComparer<List<int>>.Default.Equals(StratenNaamIdLijst, gemeente.StratenNaamIdLijst);
        }
    }
}