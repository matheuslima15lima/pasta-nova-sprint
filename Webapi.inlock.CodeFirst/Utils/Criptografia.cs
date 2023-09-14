namespace Webapi.inlock.CodeFirst.Utils
{
    public class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que recebera a hash</param>
        /// <returns>senha criptografada com a hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }


        /// <summary>
        /// Verifica se a hash da senha informada é igual á hash salva no BD
        /// </summary>
        /// <param name="senhaForm">Senha pasada no form de login</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns></returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
