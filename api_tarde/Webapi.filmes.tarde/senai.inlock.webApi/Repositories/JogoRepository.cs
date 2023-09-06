using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly string StringConexao = "Data Source = Note18-S15; Initial Catalog = inlock_games_Tarde; User Id = sa; pwd = Senai@134 ";
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new(StringConexao))
            {
                String queryInsert = "INSERT INTO Jogo(Nome,IdEstudio) VALUES(@Nome,@IdEstudio)";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
