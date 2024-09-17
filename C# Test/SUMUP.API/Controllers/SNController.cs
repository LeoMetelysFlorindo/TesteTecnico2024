using Microsoft.AspNetCore.Mvc;
using SUMUP.API.Models;
using SUMUP.API.Repository;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace SUMUP.API.Controllers
{
    // 04/09/2021 16:43h
    // Leonardo Metelis
    // Autenticação de Token na chamada de todas as API´s definidas
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    public class SNController : Controller
    {
        private readonly ISamulp_DQC342Repository _samulpDQC342Repository;
        public SNController(ISamulp_DQC342Repository Samulp_DQC342Repository)
        {
            _samulpDQC342Repository = Samulp_DQC342Repository;
        }

        // 16/09/2024 14:49h
        // Leonardo Metelis
        // Chamada de pesquisa do nome na tabela Produto
        // GET api/SN/062040010009
        /// <summary>
        /// Pesquisa um Produto pelo Nome especificado.
        /// </summary>
        /// <param name="Nome">O Nome do produto desejado</param>
        /// <returns>A table with values</returns>      
        /// <returns>Uma lista de itens de PRODUTO</returns>  
        /// <response code="204">No Content. Data Not Found for the especifications.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Error - Data Not Found!</response>
        /// <response code="500">Exception Ocorr to receive data. Internal server error".</response>
        [HttpGet("{Nome}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(Produto))]
        public async Task<ActionResult> Get(string Nome)
        {
            try
            {
                var sn = await _samulpDQC342Repository.GetSN(Nome);

                if (sn.Count() == 0) 
                {
                    return StatusCode(204, "Sem Conteúdo. Dado Não Encontrado para as especificações.");
                }
                else 
                {
                    return Ok(sn);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Exception Ocorr to receive data. Internal server error");
            }

        }
     
    }
}
