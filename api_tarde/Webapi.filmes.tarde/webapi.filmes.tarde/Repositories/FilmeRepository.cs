using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly string StringConexao = "Data Source = NOTE18-S15; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int Id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            //cria uma lista de generos onde sera armazenados os generos
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //abre a a conexao com o banco de dados
                con.Open();

                //declara o SqlDataReader para percorrer(ler) o banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que sera executada e a conexao
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto ouver registros para serem lidos no rdr o laço se repetirá
                    while (rdr.Read())
                    {
                        //Instancia um objeto do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain()
                        {
                            //atribui a propriedade Id o valor da primeira coluna da tabela
                            IdFilme = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade Titulo ao valor da coluna Titulo
                            Titulo = rdr["Titulo"].ToString(),


                        };

                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),
                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaFilmes.Add(filme);
                    }
                }
            }
            //Retorna a lista de gêneros
            return ListaFilmes;
        }
    }
}
