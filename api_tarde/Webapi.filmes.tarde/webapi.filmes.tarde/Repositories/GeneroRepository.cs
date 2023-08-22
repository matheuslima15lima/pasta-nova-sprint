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
        ///  -sqlServer : User Id sa =
        /// </summary>
        private string StringConexao = "Data Source = NOTE18-S15; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int Id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
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
