using System.Data.SqlClient;

namespace Assignment.View.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "Server=10.50.18.16;Database=training_db;User ID=SVC_TRANING;Password=Gemini@123;";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        
    }
}
