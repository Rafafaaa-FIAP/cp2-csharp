using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;
using MySql.Data.MySqlClient;

namespace GameStoreMVC.Repositorio
{
    public class GameRepositorio : IGameRepositorio
    {

        private readonly string _connectionString;

        public GameRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao");
        }

        public void CadastrarJogo(Game jogo)
        {

            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            var cmd = new MySqlCommand("INSERT INTO Games (Nome,Descricao,Dificuldade) VALUES(@nome, @descricao, @dificuldade)", conn);
            cmd.Parameters.AddWithValue("@nome", jogo.Nome);
            cmd.Parameters.AddWithValue("@telefone", jogo.Descricao);
            cmd.Parameters.AddWithValue("@dificuldade", jogo.Dificuldade);
            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Game> ListarTudo()
        {
            var lista = new List<Game>();

            using var conn = new MySqlConnection(_connectionString);

            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM Games", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Game
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString()!,
                    Descricao = reader["Descricao"].ToString()!,
                    Dificuldade = reader["Dificuldade"].ToString()!,
                });
            }
            return lista;

        }

        public Game? ObterId(int id)
        {
            using var conn = new MySqlConnection(_connectionString);

            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM Games WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Game
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString()!,
                    Descricao = reader["Descricao"].ToString()!,
                    Dificuldade = reader["Dificuldade"].ToString()!,
                };
            }
            return null;
        }

        public void EditarJogo(Game prodmodel)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            var cmd = new MySqlCommand("UPDATE Gsames SET Nome = @nome, Descricao = @descricao,Dificuldade = @dificuldade WHERE Id= @id", conn);
            cmd.Parameters.AddWithValue("@nome", prodmodel.Nome);
            cmd.Parameters.AddWithValue("@descricao", prodmodel.Descricao);
            cmd.Parameters.AddWithValue("@dificuldade", prodmodel.Dificuldade);
            cmd.Parameters.AddWithValue("@id", prodmodel.Id);
            cmd.ExecuteNonQuery();
        }

        public void ExcluirJogo(int id)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
           
            var cmd = new MySqlCommand("DELETE FROM Games WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

    }
}