using System.Collections.Generic;

namespace Tool2.Klas
{
    public class Segment
    //Een wegsegment wordt begrensd door een begin-en eindknoop
    //en verwijst naar een lijst van punten die het segment beschrijven.
    {
        #region Properties

        public int segmentID { get; set; }
        public Knoop beginknoop { get; set; }
        public Knoop eindknoop { get; set; }
        public List<Punt> punten_verticles { get; set; }



        #endregion Properties

        public Segment(int segmentID, Knoop beginknoop, Knoop eindknoop, List<Punt> lijstPunten)
        {
            this.segmentID = segmentID;
            this.beginknoop = beginknoop;
            this.eindknoop = eindknoop;
            this.punten_verticles = lijstPunten;

        }

        //gebruikt bij testen & debug
        public override string ToString()
        {
            List<string> pntLijst = null;

            punten_verticles.ForEach(p => pntLijst.Add(p.ToString()));

            return ("Segment {0}, heeft als beginknoop x,y: ({1},{2}), heeft als eindknoop x,y: ({3},{4})",
                segmentID,
                beginknoop.punt.x,
                 beginknoop.punt.y,
                  eindknoop.punt.x,
                   eindknoop.punt.y
                          )

                +
                 "/n en als verticles: " + pntLijst;
        }



        public override bool Equals(object obj)
        {
            return obj is Segment segment &&
                   EqualityComparer<Knoop>.Default.Equals(beginknoop, segment.beginknoop) &&
                   EqualityComparer<Knoop>.Default.Equals(eindknoop, segment.eindknoop) &&
                   segmentID == segment.segmentID &&
                   EqualityComparer<List<Punt>>.Default.Equals(punten_verticles, segment.punten_verticles);
        }


  

       
    }
}