using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// string de conexao com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: Nome do servidor do banco
        /// Initial Catalog: Nome do banco de dados
        /// Autenticao
        /// - windows : integrated security = true
        ///  -sqlServer : User Id = sa; pwd= senha
        /// </summary>
        private readonly string StringConexao = "Data Source = NOTE18-S15; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String queryUpdateById = $"UPDATE Genero SET Nome WHERE IdGenero = @GeneroId";

               
                using (SqlCommand cmd = new SqlCommand(queryUpdateById, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@GeneroId", genero.IdGenero);
                    cmd.ExecuteNonQuery();
                }
                //throw new NotImplementedException();
            }
        }

        public void AtualizarIdUrl(int Id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buscar um genero atraves do seu id
        /// </summary>
        /// <param name="id">Id do genero a ser buscado</param>
        /// <returns></returns>
        public GeneroDomain BuscarPorId(int id)
        {

           

            using SqlConnection con = new(StringConexao);

            string queryFindById = $"SELECT idGenero, Nome FROM Genero WHERE IdGenero = {id} ";

            using SqlCommand cmd = new(queryFindById, con);

            con.Open();

            SqlDataReader rdr;

            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                //generoBuscado é a GeneroDomain
                GeneroDomain generoBuscado = new GeneroDomain
                {
                    //atribui a propriedade IdGenero o valor da primeira coluna da tabela
                    IdGenero = Convert.ToInt32(rdr[0]),

                    //Atribui a propriedade nome ao valor da coluna nome
                    Nome = rdr["Nome"].ToString()
                };

            return generoBuscado;
            }
            return null;
            //return genero.Nome;

        }

        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informacoes que serao cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new(StringConexao))
            {
                //Declara a query que será executada
                String queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";

                //declara o sqlcommand passando a query que sera executada e a conexaocom o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

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

                String queryDelete = $"DELETE FROM Genero WHERE {id} = IdGenero ";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// Listar todos os objetos do tipo genero 
        /// </summary>
        /// <returns>Lista de objetos do tipo genero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //cria uma lista de generos onde sera armazenados os generos
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

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
                        //Instancia um objeto do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade IdGenero o valor da primeira coluna da tabela
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade nome ao valor da coluna nome
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaGeneros.Add(genero);
                    }
                }
            }
            //Retorna a lista de gêneros
            return ListaGeneros;

        }

    }
   
}
