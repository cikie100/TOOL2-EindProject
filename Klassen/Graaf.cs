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
            List<Knoop> knopen = null;

            foreach (KeyValuePair<Knoop, List<Segment>> entry in map)
            {
                knopen.Add(entry.Key);
            }

            return knopen;
        }
    }
}