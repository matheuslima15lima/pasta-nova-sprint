using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly string StringConexao = "Data Source = NOTE18-S15; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";

        public int IdFilme { get; private set; }
        public string? Titulo { get; private set; }

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String queryUpdateIdBody = $"Update Filme SET IdGenero = @IdGenero, Titulo = @Titulo WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int Id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String queryUpdateUrl = $"Update Filme SET IdGenero= @IdGenero, Titulo = @Titulo WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    con.Open();


                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public FilmeDomain BuscarPorId(int Id)
        {

            using SqlConnection con = new(StringConexao);

            string queryFindById = $"SELECT * FROM Filme INNER JOIN Genero on Filme.IdGenero = Genero.IdGenero WHERE IdFilme = {Id} ";

            using SqlCommand cmd = new(queryFindById, con);

            con.Open();

            SqlDataReader rdr;

            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {

                GeneroDomain genero = new GeneroDomain()
                {
                    IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                    Nome = rdr["Nome"].ToString()
                };

                //FilmeBuscado é a FilmeDomain
                FilmeDomain FilmeBuscado = new FilmeDomain
                {
                    //atribui a propriedade IdGenero o valor da primeira coluna da tabela
                    IdFilme = Convert.ToInt32(rdr[0]),

                    //Atribui a propriedade nome ao valor da coluna nome
                    Titulo = rdr["Titulo"].ToString(),

                    IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                    Genero = genero

                };

                return FilmeBuscado;
            }
            return null;
            //return genero.Nome;
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new(StringConexao))
            {
                //Declara a query que será executada
                String queryInsert = "INSERT INTO Filme(Titulo,IdGenero) VALUES (@Titulo,@IdGenero)";

                //declara o sqlcommand passando a query que sera executada e a conexaocom o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);


                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int id)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                String queryDelete = $"DELETE FROM Filme WHERE {id} = IdFilme ";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }

            }


        }

        public List<FilmeDomain> ListarTodos()
        {
            //cria uma lista de generos onde sera armazenados os generos
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectAll = "Select IdFilme, Genero.IdGenero, Titulo, Nome From Filme Inner Join Genero on Filme.IdGenero = Genero.IdGenero";

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
                            //atribui a propriedade Id o valor da primeira            coluna da tabela
                            IdFilme = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade Titulo ao valor da coluna           Titulo
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr[1]),


                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr[1]),

                                Nome = rdr["Nome"].ToString()
                            }



                        };

                        //Adiciona o objeto criado dentro da lista

                        ListaFilmes.Add(filme);
                    }

                };








            }

            return ListaFilmes;
        }

    }

}
