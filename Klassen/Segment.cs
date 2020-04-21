using System.Collections.Generic;

namespace Tool2.Klas
{
    public class Segment
    //Een wegsegment wordt begrensd door een begin-en eindknoop
    //en verwijst naar een lijst van punten die het segment beschrijven.
    {
        #region Properties

        public int segmentID { get; set; }
        public int beginknoop { get; set; }
        public int eindknoop { get; set; }
        public List<Punt> punten_verticles { get; set; }

        #endregion Properties

        public Segment(int segmentID, int beginknoopID, int eindknoopID)
        {
            this.segmentID = segmentID;
            this.beginknoop = beginknoopID;
            this.eindknoop = eindknoopID;
            this.punten_verticles = new List<Punt>();
        }

        //gebruikt bij testen & debug
        public override string ToString()
        {
            List<string> pntLijst = null;

            punten_verticles.ForEach(p => pntLijst.Add(p.ToString()));

            return ("Segment {0}, heeft als beginknoop x,y: ({1},{2}), heeft als eindknoop x,y: ({3},{4})",
                segmentID,
                beginknoop.ToString(),
                 eindknoop.ToString()
                          )

                +
                 "/n en als verticles: " + pntLijst;
        }

        public override bool Equals(object obj)
        {
            return obj is Segment segment &&
                   segmentID == segment.segmentID &&
                   beginknoop == segment.beginknoop &&
                   eindknoop == segment.eindknoop &&
                   EqualityComparer<List<Punt>>.Default.Equals(punten_verticles, segment.punten_verticles);
        }


    }
}