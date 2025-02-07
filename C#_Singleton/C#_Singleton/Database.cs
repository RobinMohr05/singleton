using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace C__Singleton
{
    internal class Database
    {
        public const string CONNECTION_STRING = "server=127.0.0.1;uid=root;database=singletondb";

        public MySqlConnection Connection;

        public Database()
        {
            OpenDB();
        }
        ~Database()
        {
            // Ensure the connection is closed
            if (this.Connection == null) { return; }
            if (this.Connection.State == System.Data.ConnectionState.Open)
            {
                this.Connection.Close();
            }
        }

        public void OpenDB()
        {
            // Open our database Connection
            this.Connection = new MySqlConnection(CONNECTION_STRING);
            this.Connection.Open();
        }

        public void Query()
        {
            try
            {
                // Create a command to execute a query
                string query = "SELECT * from mitarbeiter JOIN projekt_mitarbeiter ON mitarbeiter.M_ID = projekt_mitarbeiter.M_ID;";
                using (MySqlCommand command = new MySqlCommand(query, this.Connection))
                {
                    // Execute the query and get the result
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Process the data
                            Console.WriteLine(reader["M_ID"].ToString() + reader["Nachname"] + reader["Vorname"] + reader["A_ID"].ToString() + reader["M_ID"].ToString() + reader["P_ID"].ToString() + reader["Eintritt"].ToString() + reader["Austritt"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
