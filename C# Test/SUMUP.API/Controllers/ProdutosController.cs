using System;
using Microsoft.AspNetCore.Mvc;
using SUMUP.API.Models;
using SUMUP.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;


namespace SUMUP.API.Controllers
{
    // 14/09/2021 16:43h
    // Leonardo Metelis
    // Autenticação de Token na chamada de todas as API´s definidas
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ProdutosController : ControllerBase
    {
        private readonly ISamulp_DQC342Repository _samulpDQC342Repository;
                
        public ProdutosController(ISamulp_DQC342Repository Samulp_DQC342Repository)
        {
            _samulpDQC342Repository = Samulp_DQC342Repository;
            
        }


        // 16/09/2024 14:49h
        // Leonardo Metelis
        // Chamada de pesquisa da tabela Produto
        // GET api/
        /// <summary>
        /// Recupera informações de todos os Produto ordernados pelo Nome.
        /// </summary>        
        /// <returns>Uma tabela com valores</returns>      
        /// <returns>Uma lista de todos os PRODUTO</returns>  
        /// <response code="204">No Content. Data Not Found for the especifications.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Error - Data Not Found!</response>
        /// <response code="500">Exception Ocorr to receive data. Internal server error".</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(Produto))]
        public async Task<ActionResult> ListarProdutos()
        {
            try
            {
                var sn = await _samulpDQC342Repository.ListarProdutos(); 

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


        // 16/09/2024 14:49h
        // Leonardo Metelis
        // Chamada de pesquisa da Descricao na tabela Produto
        // GET api/GetDescricao/Clio 
        /// <summary>
        /// Pesquisa um Produto pelo Nome especificado.
        /// </summary>
        /// <param name="Descricao">A Descrição do produto desejado</param>
        /// <returns>A table with values</returns>      
        /// <returns>Uma lista de itens de PRODUTO</returns>  
        /// <response code="204">No Content. Data Not Found for the especifications.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Error - Data Not Found!</response>
        /// <response code="500">Exception Ocorr to receive data. Internal server error".</response>
        [HttpGet("{Descricao}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(Produto))]
        public async Task<ActionResult> GetDescricao(string Descricao)
        {
            try
            {
                var sn = await _samulpDQC342Repository.GetDESCRICAO(Descricao);

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
