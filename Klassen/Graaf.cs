using System.Collections.Generic;

namespace Tool2.Klas
{
    public class Graaf
    {
        public int GraafId { get; set; }

        public Dictionary<Knoop, List<Segment>> map { get; set; }




        public Graaf(int graafId)
        {
            this.GraafId = graafId;
            map = new Dictionary<Knoop, List<Segment>>();
        }

        public List<Knoop> getKnopen()
        {
            List<Knoop> knopen = new List<Knoop>();

            foreach (KeyValuePair<Knoop, List<Segment>> entry in this.map)
            {
                knopen.Add(entry.Key);
            }

            return knopen;
        }
    }
}