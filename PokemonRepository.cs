using MySql.Data.MySqlClient;
using Pokedex.API.Models;
using Pokedex.API.NovaPasta;
using System.Data;
using System.Data.SqlClient;

namespace Pokedex.API.Repositories
{
    public class PokemonRepository
    {
        public List<Pokemon> SelectPokemons()
        {
            List<Pokemon> pokemons;
            Pokemon pokemon = null;
               
            string connectionString = "Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Pokemons";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            pokemons = new List<Pokemon>();

                            while (reader.Read())
                            {
                                pokemon = new Pokemon();

                                pokemon.Id = reader.GetInt32(0);
                                pokemon.Name = reader.GetString(1);
                                pokemon.Description = reader.GetString(2);
                                pokemon.Type = reader.GetString(3);

                                pokemons.Add(pokemon);
                            }                          
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return pokemons;
        }

        public Pokemon GetPokemonById(int id)
        {

            string _connectionString = "Server=localhost;DataBas=PocPokemonEB;Trusted_Connection=True; TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Id, Name, Description, Type FROM Pokemons WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Pokemon pokemon = new Pokemon
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Type = reader.GetString(3)
                        };
                        return pokemon;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void InsertPokemon(Pokemon pokemon)
        {
            string _connectionString = "Server=localhost;DataBas=PocPokemonEB;Trusted_Connection=True; TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Pokemons (Id, Name, Description, Type) VALUES (@id, @Name, @Description, @Type)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", pokemon.Id);
                        command.Parameters.AddWithValue("@Name", pokemon.Name);
                        command.Parameters.AddWithValue("@Description", pokemon.Description);
                        command.Parameters.AddWithValue("@Type", pokemon.Type);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdatePokemon(Pokemon pokemon)
        {
            string _connectionString = "Server=localhost;DataBas=PocPokemonEB;Trusted_Connection=True; TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Pokemons SET Name = @Name, Description = @Description, Type = @Type WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", pokemon.Id);
                        command.Parameters.AddWithValue("@Name", pokemon.Name);
                        command.Parameters.AddWithValue("@Description", pokemon.Description);
                        command.Parameters.AddWithValue("@Type", pokemon.Type);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DeletePokemon(int id)
        {
            string _connectionString = "Server=localhost;DataBas=PocPokemonEB;Trusted_Connection=True; TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Pokemons WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
