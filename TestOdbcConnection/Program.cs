using System;
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        string connectionString = "DSN=RFID_DB;UID=sa;PWD=Id.2009.Sistemas*;DATABASE=RFID;";


        using (OdbcConnection connection = new OdbcConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa");

                string query = "SELECT TOP 50 * FROM dbo.Activos"; 

                using (OdbcCommand command = new OdbcCommand(query, connection))
                {
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ACT_ID: {reader["ACT_ID"]}, NOMBRE_ACTIVO: {reader["NOMBRE_ACTIVO"]}");
                        }
                    }
                }
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
            }
        }
    }
}
