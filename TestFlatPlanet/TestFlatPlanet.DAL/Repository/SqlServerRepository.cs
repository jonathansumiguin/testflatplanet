using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFlatPlanet.DAL.Repository
{
    public class SqlServerRepository
    {
        private readonly string connString;
        public SqlServerRepository(string connectionString)
        {
            connString = connectionString;
        }
        public bool CheckIfDatabaseExists()
        {
            int? databaseId;
            try {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT database_id FROM sys.databases WHERE Name = 'TestFlatPlanetDb'", conn))
                    {
                        databaseId = (int?)command.ExecuteScalar();
                    }
                }

                return databaseId != null;
            }
            catch
            {
                return false;
            }
        }

        public void CreateDatabaseObjects()
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "CREATE DATABASE TestFlatPlanetDb";
                    command.ExecuteNonQuery();
                }

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "USE [TestFlatPlanetDb] CREATE TABLE dbo.[Counter] ([Counter] SMALLINT)";
                    command.ExecuteNonQuery();

                }

                var insertCommand = " INSERT INTO dbo.Counter" +
                                    " (Counter)" +
                                    " VALUES" +
                                    " (0)";
                using (var command = new SqlCommand(insertCommand, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        } 
    }
}
