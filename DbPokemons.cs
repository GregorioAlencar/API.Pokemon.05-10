using System.Data.SqlClient;

namespace Pokedex.API.NovaPasta
{
    public class DbPokemons
    {
        string ConnectionString { get; set; }
        
        public DbPokemons() 
        {
            ConnectionString = "Server=.\\SQLEXPRESS;Database=PocPokemondb;Trusted_Connection=true;TrustServerCertificate=true;";
        }

        public SqlConnection CreaConnection()
        { 
            try
            {
                return new SqlConnection(ConnectionString);
            }

            catch (Exception exception) 
            {
                throw exception;
            }
        }

        internal SqlConnection CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
