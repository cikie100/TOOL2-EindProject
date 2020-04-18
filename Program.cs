using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Tool2.Databeheer;
using Tool2.DbDatabeheer;
using Tool2.Klas;

namespace Tool2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            #region tekst binnenLezen
            Databeheerder d = new Databeheerder();

            //haalt alles op van de tekstbestanden die ik maakte in TOOL1
            List<Gemeente> GemeenteLijst = d.getGemeentes(); //duurt <0 seconden
            List<Provincie> ProvincieLijst = d.getProvincies(); //duurt < 0 seconden
            List<Straat> StratenLijst = d.getStraten(); //duurt < 0 seconden

           
            #endregion

            #region  databank
            DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);

            //die @ moet erbij, anders geeft die gezaag over de "\"
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=LaboProjectDB;Integrated Security=True";
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");

            DB_DataBeheer db = new DB_DataBeheer(sqlFactory, connectionString);

            #endregion

            //--dbo.Provincie opvullen is gelukt (ProvincieID, provincienaam, taalcode)
            // db.VoegProvinciesToe(ProvincieLijst);

            //--dbo.Provincie_Gemeente opvullen is gelukt (ProvincieID, GemeenteId)
            //heb je nodig als link tussen provincies en gemeentes
            // db.KoppelGemeentesAanProvincie(ProvincieLijst);

            //--dbo.Gemeente opvullen is gelukt (GemeenteId,GemeenteNaam)
            // db.VoegGemeentesToe(GemeenteLijst);

            //--dbo.Gemeente_straat opvullen is gelukt (GemeenteId, straatId)
            //heb je nodig als link tussen gemeentes en hun straten
            // db.KoppelStratenAanGemeentes(GemeenteLijst, StratenLijst);


            //--door de foreign key moet je eerst graafDB maken en dan pas straatDB
            //--dbo.Graaf vullen met alle graafId's (GraafId)
            // db.VoegGraafObjectenToe(StratenLijst);

            //--dbo.Straat vullen is gelukt (StraatID,Straatnaam,Length,GraafId)
            // db.VoegStratenToe(StratenLijst);




            stopWatch.Stop();
            long duration = stopWatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("\nRunTime " + duration + " Elapsed seconds");

            Console.ReadLine(); 
        }
    }
}
