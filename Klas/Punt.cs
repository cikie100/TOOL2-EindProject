namespace Tool2.Klas
{
    public class Punt
    //Een punt is gekenmerkt door zijn x-en y-coördinaat.
    {
        #region Properties

        public double x { get; set; }
        public double y { get; set; }

        #endregion Properties

        //constructor
        public Punt(double d1, double d2)
        {
            this.x = d1;
            this.y = d2;
        }

        //gebruikt voor testen en debug
        public override string ToString()
        {
            return "Punt met x,y: ( " + x.ToString() + "," + y.ToString() + ")";
        }
        public override bool Equals(object obj)
        {
            return obj is Punt punt &&
                   x == punt.x &&
                   y == punt.y;
        }
    }
}