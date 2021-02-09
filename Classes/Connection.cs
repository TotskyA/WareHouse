using MySql.Data.MySqlClient;

namespace WarehouseApp.Classes
{
    class Connection
    {
        private static MySqlConnection connection;
        private static bool isConnected = false;
        public static string ConnectionError { get; private set; }

        public static bool Connect (string server, string database, string login, string password)
        {
            if(connection == null)
            {
                connection = new MySqlConnection("Data Source=" + server + ";Database=" + database + ";User ID=" + login + ";Password=" + password);
                try
                {
                    connection.Open();
                    isConnected = true;
                }
                catch (MySqlException ex)
                {
                    connection = null;
                    ConnectionError = ex.Message;
                    return false;
                }
            }
            return true;
        }

        public static bool IsConnected ()
        {
            return isConnected;
        }

        public static MySqlConnection GetConnection ()
        {
            return connection;
        }
    }
}
