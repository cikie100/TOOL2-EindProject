using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Tool2.Databeheer;
using Tool2.DbDatabeheer;
using Tool2.Klas;

namespace Tool2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            #region tekst binnenLezen

            Tool1DataVerwerker t1dv = new Tool1DataVerwerker();

            //haalt alles op van de tekstbestanden die ik maakte in TOOL1
            List<Gemeente> GemeenteLijst = t1dv.getGemeentes(); //duurt <0 seconden
            List<Provincie> ProvincieLijst = t1dv.getProvincies(); //duurt < 0 seconden
            List<Straat> StratenLijst = t1dv.getStraten(); // 84064 straten maken duurt < 0 seconden
            List<Graaf> GravenLijst = t1dv.getGraafenLijst(); // duurt 30 seconden voor 84064 graven aan (=evenveel straten) te maken.

            //nodig gehad om dbo.Knoop aan te maken
            // List<Knoop> getalleknopen = t1dv.getalleknopen.GroupBy(kn => kn.knoopID).Select(grp => grp.First()).ToList(); 
            
            //nodig gehad om dbo.Punt aan te maken
            // List<Segment> segments = t1dv.getallesegmenten;
            #endregion tekst binnenLezen

            #region databank

            DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);

            //die @ moet erbij, anders geeft die gezaag over de "\"
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=LaboProjectDB;Integrated Security=True";
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");

            DB_DataBeheer db = new DB_DataBeheer(sqlFactory, connectionString);

            #endregion databank

            //Hieronder staan al de gebruikte methodes die nodig waren om mijn DB op te vullen.

            //--dbo.Provincie opvullen is gelukt (ProvincieID, provincienaam, taalcode)
            // db.VoegProvinciesToe(ProvincieLijst);

            //--dbo.Provincie_Gemeente opvullen is gelukt (ProvincieID, GemeenteId)
            //heb je nodig als link tussen provincies en gemeentes
            // db.KoppelGemeentesAanProvincie(ProvincieLijst);

            //--dbo.Gemeente opvullen is gelukt (GemeenteId,GemeenteNaam)
            // db.VoegGemeentesToe(GemeenteLijst);


            //--door de foreign key moet je eerst graafDB maken en dan pas straatDB
            //--dbo.Graaf vullen met alle graafId's (GraafId)
            // db.VoegGraafObjectenToe(StratenLijst);

            //--dbo.Straat vullen is gelukt (StraatID,Straatnaam,Length,GraafId)
            // db.VoegStratenToe(StratenLijst);

            //--dbo.Gemeente_straat opvullen is gelukt (GemeenteId, straatId)
            //heb je nodig als link tussen gemeentes en hun straten
            //  db.KoppelStratenAanGemeentes(GemeenteLijst, StratenLijst);

            //--dbo.Knoop opvullen is gelukt (knoopId, puntX, puntY)
            // db.VoegKnopenToe( getalleknopen);

            //--dbo.Graaf_Knoop opvullen is gelukt (GraafId, KnoopId)
            // db.KoppelKnopenAanGraaf(GravenLijst);

            //--dbo.Segment opvullen is gelukt (SegmentId, BeginKnoopId, EindKnoopId)
            // db.VoegSegmentenToe(GravenLijst);

            //--dbo.Knoop_Segment opvullen is gelukt (SegmentId, KnoopId)
            // db.KoppelSegmentenAanKnopen(GravenLijst); //209seconden voor 966799 rows aan te maken
            
            //--dbo.Punt opvullen is gelukt (SegmentId, PuntX, PuntY)
            // db.VoegPuntenToe(segments); // 1603 seconden (= 26.7 minutes) voor 4 687 120 punten te maken

            stopWatch.Stop();
            long duration = stopWatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("\nRunTime " + duration + " Elapsed seconds");

             Console.ReadLine();
        }
    }
}