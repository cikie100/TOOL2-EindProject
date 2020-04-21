using System.Collections.Generic;

namespace Tool2.Klas
{
    public class Knoop
    //Een knoop heeft een knoop-ID en verwijst naar een punt.
    {
        #region Properties

        public int knoopID { get; set; }
        public Punt punt { get; set; }
        public List<Segment> segmenten { get; set; }

        #endregion Properties

        public Knoop(int id, Punt p)
        {
            this.knoopID = id;
            this.punt = p;
            this.segmenten = new List<Segment>();
        }

        public override string ToString()
        {
            return ("Knoop met id " + knoopID + " , verwijst naar punt x,y: ( " + punt.x + " , " + punt.y + " )");
        }


        #region equals & getHashCode

        public override bool Equals(object obj)
        {
            return obj is Knoop knoop &&
                   knoopID == knoop.knoopID &&
                   EqualityComparer<Punt>.Default.Equals(punt, knoop.punt);
        }

        #endregion equals & getHashCode

        //
    }
}