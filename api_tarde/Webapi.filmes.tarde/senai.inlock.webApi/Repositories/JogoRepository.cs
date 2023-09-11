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
                String queryInsert = "INSERT INTO Jogo(Nome,IdEstudio,Valor,Descricao,DataLancamento) VALUES(@Nome,@IdEstudio,@Valor,@Descricao,@DataLancamento)";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);


                    con.Open();

                    cmd.ExecuteNonQuery();
                
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String queryDelete = $"DELETE FROM Jogo WHERE {id} = IdJogo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "Select IdJogo, Estudio.IdEstudio, Descricao, Valor, Jogo.Nome as NomeJogo, Estudio.Nome as NomeEstudio From Jogo Inner Join Estudio on Jogo.IdEstudio = Estudio.IdEstudio  ";

                con.Open();

                SqlDataReader rdr;
                
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read()) 
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),

                            Nome = rdr["NomeJogo"].ToString(),
                            IdEstudio = Convert.ToInt32(rdr[1]),
                            //Descricao = rdr["Descricao"].ToString(),
                           


                            Estudio = new EstudioDomain() 
                            {
                                IdEstudio= Convert.ToInt32(rdr[1]),
                                Nome = rdr["NomeEstudio"].ToString()
                            }

                        };

                        ListaJogos.Add(jogo);

                    }
                };
            }
            return ListaJogos;
        }

    }
}
