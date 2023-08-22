using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisicao sera no seguinte formato
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    
    ///Define que é um controlador de API
    [ApiController]

    /// DEFINE QUE O TIPO DE RESPOSTA DA API É JSON
    [Produces("application/json")]
    public class GenerosController : ControllerBase
    {
    }
}
