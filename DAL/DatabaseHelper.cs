using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SecureVaultApp.DAL
{
    public abstract class DatabaseHelper
    {
        // Default connection string - adjust if using a named instance in SSMS
        protected string connectionString = @"Server=.;Database=SecureVaultDB;Integrated Security=True;";

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        protected void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
