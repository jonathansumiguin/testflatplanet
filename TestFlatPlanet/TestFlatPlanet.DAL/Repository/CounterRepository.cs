using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFlatPlanet.DAL.Repository
{
    public class CounterRepository
    {
        private readonly string connString;
        public CounterRepository(string connectionString)
        {
            connString = connectionString;
        }
        public int GetCount()
        {
            int count;

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var command = new SqlCommand("USE [TestFlatPlanetDb] SELECT TOP 1 ISNULL(Counter, 0) AS Counter FROM dbo.Counter", conn))
                {
                    count = int.Parse(command.ExecuteScalar().ToString());
                }
            }

            return count;
        }

        public void UpdateCount()
        {
            var sqlCommand = "USE [TestFlatPlanetDb]" +
                            "UPDATE dbo.Counter" +
                            " SET Counter = ISNULL(Counter, 0) + 1";

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var command = new SqlCommand(sqlCommand, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
