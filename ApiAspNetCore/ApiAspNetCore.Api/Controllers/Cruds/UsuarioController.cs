using LSCode.Facilitador.Api.Results;
using LSCode.Validador.ValidacoesNotificacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiAspNetCore.Api.Controllers.Cruds
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Health Check
        /// </summary>        
        /// <remarks><h2><b>Afere a resposta deste contexto do serviço.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/HealthCheck")]
        [ProducesResponseType(typeof(ApiResponse<string, Notificacao>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string, Notificacao>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<string, Notificacao>), StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse<string, Notificacao>> UsuarioHealthCheck()
        {
            try
            {
                //if (Request.Headers["ChaveAPI"].ToString() != _ChaveAPI)
                //    return StatusCode(StatusCodes.Status401Unauthorized, new ApiResponse<object, Notificacao>("Acesso negado", new List<Notificacao>() { new Notificacao("Chave da API", "ChaveAPI não corresponde com a chave esperada") }));

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<string, Notificacao>("Sucesso", "API Asp.Net Core 2.1 - Usuário OK"));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object, Notificacao>("Erro", new List<Notificacao>() { new Notificacao("Erro", e.Message) }));
            }
        }

        [HttpGet]
        [Route("v1/Usuarios")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}