using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Tool2.Klas;

namespace Tool2.DbDatabeheer
{
    public class DB_DataBeheer {
        //Voorbeeld gebruikt: ADONETtutorial

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
        #endregion

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

        #endregion



    }
}
