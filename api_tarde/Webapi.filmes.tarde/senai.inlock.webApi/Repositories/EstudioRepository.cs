using System.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly string StringConexao = "Data Source = Note18-S15; Initial Catalog = inlock_games_Tarde; User Id = sa; pwd = Senai@134 ";
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new(StringConexao))
            {
                String queryInsert = "INSERT INTO Estudio(Nome) VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }

            }

        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String queryDelete = $"DELETE FROM Estudio WHERE {id} = IdEstudio";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
           List<EstudioDomain> ListaEstudios= new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

                con.Open();

                SqlDataReader rdr;
                
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read()) 
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString()
                        };
                        ListaEstudios.Add(estudio);
                    }
                }
            }
            return ListaEstudios;
        }
    }
}
