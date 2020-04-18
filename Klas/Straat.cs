namespace Tool2.Klas
{
    public class Straat
    {
        public int StraatID { get; set; }
        public string Straatnaam { get; set; }
        public double Length { get; set; }
        public int GraafId { get; set; }

        public Straat(int straatID, string straatnaam, double length, int graafId)
        {
            StraatID = straatID;
            Straatnaam = straatnaam;
            Length = length;
            GraafId = graafId;
        }

        public override bool Equals(object obj)
        {
            return obj is Straat straat &&
                   StraatID == straat.StraatID &&
                   Straatnaam == straat.Straatnaam &&
                   Length == straat.Length &&
                   GraafId == straat.GraafId;
        }
    }
}