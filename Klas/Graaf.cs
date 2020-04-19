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
    }
}