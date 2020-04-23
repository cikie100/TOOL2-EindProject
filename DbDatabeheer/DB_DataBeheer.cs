using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Tool2.Klas;

namespace Tool2.DbDatabeheer
{
    public class DB_DataBeheer
    {
        //Voorbeeld gebruikt: ADONETtutorial
        //namen zeggen welke items ze inserten in de databank

        #region standaard stuff ( DbProviderFactory, DbConnection, constructor,... )

        private DbProviderFactory sqlFactory;

        //connectionString gemaakt in Program.cs
        private string connectionString;

        public DB_DataBeheer(DbProviderFactory sqlFactory, string connectionString)
        {
            this.sqlFactory = sqlFactory;
            this.connectionString = connectionString;
        }

        private DbConnection getConnection()
        {
            //Once you create the provider factory, you can then use its methods to create additional objects.
            //Some of the methods of a SqlClientFactory include CreateConnection, CreateCommand, and CreateDataAdapter.
            DbConnection connection = sqlFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        #endregion standaard stuff ( DbProviderFactory, DbConnection, constructor,... )

        #region lukt

        public void VoegGemeentesToe(List<Gemeente> gemlist)
        {
            DbConnection connection = getConnection();
            string query1 = "SET IDENTITY_INSERT Gemeente ON;" +
                "INSERT INTO dbo.Gemeente(GemeenteId,GemeenteNaam) VALUES(@gemeenteId,@gemeenteNaam);" +
                "   SET IDENTITY_INSERT Gemeente  OFF";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@gemeenteId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);

                    DbParameter parSID = sqlFactory.CreateParameter();
                    parSID.ParameterName = "@gemeenteNaam";
                    parSID.DbType = DbType.String;
                    command.Parameters.Add(parSID);

                    command.CommandText = query1;

                    foreach (Gemeente gem in gemlist)
                    {
                        command.Parameters["@gemeenteId"].Value = gem.GemeenteId;
                        command.Parameters["@gemeenteNaam"].Value = gem.GemeenteNaam;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VoegProvinciesToe(List<Provincie> provlist)
        {
            DbConnection connection = getConnection();
            string query1 = "SET IDENTITY_INSERT Provincie ON;" +
                "INSERT INTO dbo.Provincie(provincieID,provincienaam,taalcode) VALUES(@provincieID,@provincienaam,@taalcode);" +
                "   SET IDENTITY_INSERT Provincie  OFF";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@provincieID";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);

                    DbParameter parSID = sqlFactory.CreateParameter();
                    parSID.ParameterName = "@provincienaam";
                    parSID.DbType = DbType.String;
                    command.Parameters.Add(parSID);

                    DbParameter parTID = sqlFactory.CreateParameter();
                    parTID.ParameterName = "@taalcode";
                    parTID.DbType = DbType.String;
                    command.Parameters.Add(parTID);

                    command.CommandText = query1;

                    foreach (Provincie prov in provlist)
                    {
                        command.Parameters["@provincieID"].Value = prov.ProvincieId;
                        command.Parameters["@provincienaam"].Value = prov.ProvincieNaam;
                        command.Parameters["@taalcode"].Value = prov.TaalCodeProvincieNaam;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
        public void VoegGraafObjectenToe(List<Straat> straatlist) //duurt 23 seconden , er zijn er 84063
        {
            DbConnection connection = getConnection();
            string query1 = "SET IDENTITY_INSERT Graaf ON;" +
                "INSERT INTO dbo.Graaf(GraafId) VALUES(@GraafId);" +
                "   SET IDENTITY_INSERT Graaf  OFF";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@GraafId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);

                    command.CommandText = query1;

                    foreach (Straat str in straatlist)
                    {
                        command.Parameters["@graafID"].Value = str.GraafId;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VoegStratenToe(List<Straat> straatlist) //duurt ook 23 secondenn er zijn er 84063
        {
            DbConnection connection = getConnection();
            string query1 = "SET IDENTITY_INSERT Straat ON;" +
                "INSERT INTO dbo.Straat(straatId,straatNaam,lengte,graafID) VALUES(@straatId,@straatNaam,@lengte,@graafID);" +
                "   SET IDENTITY_INSERT Straat  OFF";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@straatId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);

                    DbParameter parSID = sqlFactory.CreateParameter();
                    parSID.ParameterName = "@straatNaam";
                    parSID.DbType = DbType.String;
                    command.Parameters.Add(parSID);

                    DbParameter parTID = sqlFactory.CreateParameter();
                    parTID.ParameterName = "@lengte";
                    parTID.DbType = DbType.Int32;
                    command.Parameters.Add(parTID);

                    DbParameter parRID = sqlFactory.CreateParameter();
                    parRID.ParameterName = "@graafID";
                    parRID.DbType = DbType.Int32;
                    command.Parameters.Add(parRID);

                    command.CommandText = query1;

                    foreach (Straat str in straatlist)
                    {
                        command.Parameters["@straatId"].Value = str.StraatID;
                        command.Parameters["@straatNaam"].Value = str.Straatnaam;
                        command.Parameters["@lengte"].Value = str.Length;
                        command.Parameters["@graafID"].Value = str.GraafId;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void KoppelGemeentesAanProvincie(List<Provincie> provlist)
        {
            DbConnection connection = getConnection();
            string queryS = "INSERT INTO dbo.Provincie_Gemeente(provincieID,gemeenteId) VALUES(@provincieID,@gemeenteId)";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@provincieID";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);
                    DbParameter parSID = sqlFactory.CreateParameter();
                    parSID.ParameterName = "@gemeenteId";
                    parSID.DbType = DbType.Int32;
                    command.Parameters.Add(parSID);

                    command.CommandText = queryS;

                    foreach (Provincie prov in provlist)
                    {
                        foreach (int gemid in prov.GemeenteIdStrings)
                        {
                            command.Parameters["@provincieID"].Value = prov.ProvincieId;
                            command.Parameters["@gemeenteId"].Value = gemid;
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void KoppelStratenAanGemeentes(List<Gemeente> gemlist, List<Straat> stralist)
        {
            DbConnection connection = getConnection();
            string queryS = "INSERT INTO dbo.Gemeente_straat(gemeenteId,straatId) VALUES(@gemeenteId,@straatId)";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@gemeenteId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);
                    DbParameter parSID = sqlFactory.CreateParameter();
                    parSID.ParameterName = "@straatId";
                    parSID.DbType = DbType.Int32;
                    command.Parameters.Add(parSID);

                    command.CommandText = queryS;

                    foreach (Gemeente gem in gemlist)
                    {
                        foreach (int strtid in gem.StratenNaamIdLijst)
                        {
                            //een extra check omdat straat 83 van eerste gemeente er niet is in stratenlijst
                            if (stralist.Exists(str => str.StraatID.Equals(strtid)))
                            {
                                command.Parameters["@gemeenteId"].Value = gem.GemeenteId;
                                command.Parameters["@straatId"].Value = strtid;
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VoegKnopenToe(List<Knoop> getalleknopen) 
        {
            DbConnection connection = getConnection();
            string query1 = "SET IDENTITY_INSERT Knoop ON;" +
                " INSERT INTO dbo.Knoop(knoopId,puntX,puntY) VALUES(@knoopId,@puntX,@puntY);" +
                "   SET IDENTITY_INSERT Knoop  OFF";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@knoopId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);

                    DbParameter parTID = sqlFactory.CreateParameter();
                    parTID.ParameterName = "@puntX";
                    parTID.DbType = DbType.Double;
                    command.Parameters.Add(parTID);

                    DbParameter parWID = sqlFactory.CreateParameter();
                    parWID.ParameterName = "@puntY";
                    parWID.DbType = DbType.Double;
                    command.Parameters.Add(parWID);

                    command.CommandText = query1;


                
                  
                    foreach (Knoop Key in getalleknopen)
                    {
                        command.Parameters["@knoopId"].Value = Key.knoopID;
                        command.Parameters["@puntX"].Value = Key.punt.x;
                        command.Parameters["@puntY"].Value = Key.punt.y;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void KoppelKnopenAanGraaf(List<Graaf> GravenLijst)
        {
            DbConnection connection = getConnection();
            string queryS = "INSERT INTO dbo.Graaf_Knoop(GraafId,knoopId) VALUES(@GraafId,@knoopId)";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@GraafId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);

                    DbParameter parSID = sqlFactory.CreateParameter();
                    parSID.ParameterName = "@knoopId";
                    parSID.DbType = DbType.Int32;
                    command.Parameters.Add(parSID);

                    command.CommandText = queryS;
                    GravenLijst = GravenLijst.OrderBy(g => g.GraafId).ToList();

                    foreach (Graaf graaf in GravenLijst)
                    {
                        List<Knoop> knopen = graaf.getKnopen().GroupBy(kn => kn.knoopID).Select(grp => grp.First()).ToList(); ;

                        foreach (Knoop knoop in knopen)
                        {
                            command.Parameters["@GraafId"].Value = graaf.GraafId;
                            command.Parameters["@knoopId"].Value = knoop.knoopID;
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VoegSegmentenToe(List<Graaf> GravenLijst)
        {
            DbConnection connection = getConnection();
            string query1 = "SET IDENTITY_INSERT Segment ON;" +
                " INSERT INTO dbo.Segment(SegmentId,BeginKnoopId,EindKnoopId) " +
                "VALUES(@SegmentId,@BeginKnoopId,@EindKnoopId);" +
                "   SET IDENTITY_INSERT Segment  OFF";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@SegmentId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);


                    DbParameter parWID = sqlFactory.CreateParameter();
                    parWID.ParameterName = "@BeginKnoopId";
                    parWID.DbType = DbType.Int32;
                    command.Parameters.Add(parWID);

                    DbParameter parTWID = sqlFactory.CreateParameter();
                    parTWID.ParameterName = "@EindKnoopId";
                    parTWID.DbType = DbType.Int32;
                    command.Parameters.Add(parTWID);


                    command.CommandText = query1;

                    foreach (Graaf grf in GravenLijst)
                    {
                        //  Dictionary<Knoop, List<Segment>> values = grf.map;

                        List<Segment> listy = grf.getSegmenten();


                        foreach (Segment segm in listy)
                        {
                            command.Parameters["@SegmentId"].Value = segm.segmentID;
                            command.Parameters["@BeginKnoopId"].Value = segm.beginknoop;
                            command.Parameters["@EindKnoopId"].Value = segm.eindknoop;
                            command.ExecuteNonQuery();
                        }



                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VoegPuntenToe(List<Segment> segments)
        {
            DbConnection connection = getConnection();
            string query1 = "SET IDENTITY_INSERT Segment ON;" +
                " INSERT INTO dbo.Punt(SegmId,puntX,puntY) " +
                "VALUES(@SegmId,@puntX,@puntY);" +
                "   SET IDENTITY_INSERT Segment  OFF";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@SegmId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);


                    DbParameter parWID = sqlFactory.CreateParameter();
                    parWID.ParameterName = "@puntX";
                    parWID.DbType = DbType.Double;
                    command.Parameters.Add(parWID);

                    DbParameter parTWID = sqlFactory.CreateParameter();
                    parTWID.ParameterName = "@puntY";
                    parTWID.DbType = DbType.Double;
                    command.Parameters.Add(parTWID);

                    command.CommandText = query1;
                    List<Segment> segmentsUn = segments.GroupBy(s => s.segmentID).Select(grp => grp.First()).ToList();

                    foreach (Segment seg in segmentsUn)
                    {

                        foreach (Punt punt in seg.punten_verticles)
                        {
                            command.Parameters["@SegmId"].Value = seg.segmentID;
                            command.Parameters["@puntX"].Value = punt.x;
                            command.Parameters["@puntY"].Value = punt.y;
                            command.ExecuteNonQuery();
                        }



                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void KoppelSegmentenAanKnopen(List<Graaf> gravenLijst)
        {
            DbConnection connection = getConnection();
            string query1 =
                " INSERT INTO dbo.Knoop_Segment(knoopId,SegmentId ) " +
                "VALUES(@knoopId,@SegmentId); ";

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@knoopId";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);

                    DbParameter parWID = sqlFactory.CreateParameter();
                    parWID.ParameterName = "@SegmentId";
                    parWID.DbType = DbType.Int32;
                    command.Parameters.Add(parWID);


                    command.CommandText = query1;

                    foreach (Graaf grf in gravenLijst)
                    {
                        //  Dictionary<Knoop, List<Segment>> values = grf.map;
                        foreach (KeyValuePair<Knoop, List<Segment>> KVP in grf.map)
                        {
                            foreach (Segment segm in KVP.Value)
                            {

                                command.Parameters["@SegmentId"].Value = segm.segmentID;
                                command.Parameters["@knoopId"].Value = KVP.Key.knoopID;
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion lukt
        public void updateSegmenten(List<Graaf> gravenLijst)
        {
            DbConnection connection = getConnection();
            string query1 =
                " UPDATE dbo.Segment" +
                " SET linksStraatnaamID= @linksStraatnaamID, rechtsStraatnaamID= @rechtsStraatnaamID " +
                "WHERE SegmentId= @SegmentId";
              

            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    DbParameter parCID = sqlFactory.CreateParameter();
                    parCID.ParameterName = "@linksStraatnaamID";
                    parCID.DbType = DbType.Int32;
                    command.Parameters.Add(parCID);


                    DbParameter parWID = sqlFactory.CreateParameter();
                    parWID.ParameterName = "@rechtsStraatnaamID";
                    parWID.DbType = DbType.Int32;
                    command.Parameters.Add(parWID);

                    DbParameter parTWID = sqlFactory.CreateParameter();
                    parTWID.ParameterName = "@SegmentId";
                    parTWID.DbType = DbType.Int32;
                    command.Parameters.Add(parTWID);


                    command.CommandText = query1;

                    foreach (Graaf grf in gravenLijst)
                    {
                        //  Dictionary<Knoop, List<Segment>> values = grf.map;

                        List<Segment> listy = grf.getSegmenten();


                        foreach (Segment segm in listy)
                        {
                            command.Parameters["@linksStraatnaamID"].Value = segm.linksStraatnaamID;
                            command.Parameters["@rechtsStraatnaamID"].Value = segm.rechtsStraatnaamID;
                            command.Parameters["@SegmentId"].Value = segm.segmentID;
                            command.ExecuteNonQuery();
                        }



                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


    }
}