using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Server
{
    internal class SqlStream
    {
        private DataTable SqlTable;
        private SqlConnection SqlConnection;
        private SqlDataAdapter SqlDataAdapter;
        private SqlCommand SqlCommand;

        public SqlStream(string sqlConnection)
        {
            SqlConnection = new SqlConnection(sqlConnection);
            SqlDataAdapter = new SqlDataAdapter();
            SqlTable = new DataTable();
        }

        public string Authenticate(List<string> userData)
        {
            string serverResponse = "Invalid values";

            string pass = userData[1] + "6bd024524deba188fcc";
            byte[] buffer = Encoding.UTF8.GetBytes(pass);

            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(buffer);

            string username = userData[0];
            string passwordHash = Encoding.UTF8.GetString(hash);
            string mode = userData[2];

            Console.WriteLine($"username = {username}");
            Console.WriteLine($"passwordHash = {passwordHash}");
            Console.WriteLine($"MODE = {mode}");

            if (mode == "/SIGN_UP")
            {
                string query = "SELECT * FROM users WHERE username = @username";

                SqlCommand = new SqlCommand(query, SqlConnection);

                SqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                SqlCommand.Parameters["@username"].Value = username;

                SqlDataAdapter.SelectCommand = SqlCommand;

                SqlTable.Clear();
                SqlDataAdapter.Fill(SqlTable);

                if (SqlTable.Rows.Count > 0) 
                {
                    serverResponse = "Username already taken";
                    return serverResponse;
                }

                else

                {
                    query = "INSERT INTO users (username, pword) VALUES (@username, @pword)";

                    SqlCommand = new SqlCommand(query, SqlConnection);

                    SqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                    SqlCommand.Parameters["@username"].Value = username;

                    SqlCommand.Parameters.Add("@pword", SqlDbType.VarChar);
                    SqlCommand.Parameters["@pword"].Value = passwordHash;

                    SqlConnection.Open();

                    int affectedRows = SqlCommand.ExecuteNonQuery();

                    SqlConnection.Close();

                    if (affectedRows > 0)
                    {
                        serverResponse = "/SIGN_UP_SUCCESS";
                        return serverResponse;
                    }
                }
            }

            else if (mode == "/SIGN_IN")

            {
                string query = "SELECT * FROM users WHERE username = @username";

                SqlCommand = new SqlCommand(query, SqlConnection);

                SqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                SqlCommand.Parameters["@username"].Value = username;

                SqlDataAdapter.SelectCommand = SqlCommand;

                SqlTable.Clear();
                SqlDataAdapter.Fill(SqlTable);         

                if (SqlTable.Rows.Count == 1)
                {
                    query = "SELECT * FROM users WHERE username = @username AND pword = @pword";

                    SqlCommand = new SqlCommand(query, SqlConnection);

                    SqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                    SqlCommand.Parameters["@username"].Value = username;

                    SqlCommand.Parameters.Add("@pword", SqlDbType.VarChar);
                    SqlCommand.Parameters["@pword"].Value = passwordHash;

                    SqlDataAdapter.SelectCommand = SqlCommand;

                    SqlTable.Clear();
                    SqlDataAdapter.Fill(SqlTable);

                    if (SqlTable.Rows.Count == 1)
                    {
                        serverResponse = "/SIGN_IN_SUCCESS";
                        return serverResponse;
                    }

                    else

                    {
                        serverResponse = "Invalid login or password";
                        return serverResponse;
                    }
                }

                else
                {
                    serverResponse = "User not found";
                    return serverResponse;
                }
            }

            return serverResponse;
        }
    }
}
