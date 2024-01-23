using MySqlConnector;

namespace TryTestContainers
{
    public class MySqlConnect
    {
        public bool TryConnect(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                return true;
            }
        }
    }
}
