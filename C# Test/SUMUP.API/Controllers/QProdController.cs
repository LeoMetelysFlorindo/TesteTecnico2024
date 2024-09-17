using Microsoft.AspNetCore.Mvc;
using SUMUP.API.Models;
using SUMUP.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace SUMUP.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class QProdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QProdController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 17/09/2024 00:41h
        // Leonardo Metelis
        // Chamada Delete da tabela Produto
        // GET api/
        /// <summary>
        /// Deleta um item da tabela Produto pelo Nome. 
        /// </summary>        
        /// <returns>Sem dados a retornar</returns>              
        /// <response code="204">No Content. Data Not Found for the especifications.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Error - Data Not Found!</response>
        /// <response code="500">Exception Ocorr to receive data. Internal server error".</response>
        [HttpDelete ("{Nome}") ]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(Produto))]
        public async Task<ActionResult> DeleteProduto(string Nome)
        {
            var produto = await _context.Produtos.FindAsync(Nome);
            if (Nome == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        // 17/09/2024 13:25h
        // Leonardo Metelis
        // Chamada de Edição da tabela Produto
        // PUT api/
        /// <summary>
        /// Edita um item da tabela Produto pelo Nome. 
        /// </summary>        
        /// <returns>Sem dados a retornar</returns>              
        /// <response code="204">No Content. Data Not Found for the especifications.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Error - Data Not Found!</response>
        /// <response code="500">Exception Ocorr to receive data. Internal server error".</response>
        [HttpPut("{Nome},{Descricao},{Preco},{Data_da_validade},{Categoria}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(Produto))]
        public async Task<ActionResult> Putroduto(string Nome,string Descricao, double Preco, DateTime Data_da_validade, int Categoria, Produto produto)
        {
            var produto1 = await _context.Produtos.FindAsync(Nome);

            if (Nome == null)
            {
                return NotFound();
            }

            if (Nome != produto1.Nome)
            {
                return BadRequest();
            }
                       

            // Edição de Item
            _context.Entry(produto1).State = EntityState.Modified;

            produto1.Descricao = Descricao;
            produto1.Preco = Preco;
            produto1.Data_da_validade = Data_da_validade;
          

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Nome))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // 17/09/2024 13:25h
        // Leonardo Metelis
        // Chamada de Edição da tabela Produto
        // POST api/
        /// <summary>
        /// SALVA/INSERE um item na tabela Produto pelo Nome. 
        /// </summary>        
        /// <returns>Sem dados a retornar</returns>              
        /// <response code="204">No Content. Data Not Found for the especifications.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Error - Data Not Found!</response>
        /// <response code="500">Exception Ocorr to receive data. Internal server error".</response>
        [HttpPost("{Nome},{Descricao},{Preco},{Data_da_validade},{Categoria}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(Produto))]
        public async Task<ActionResult> PostProduto(string Nome, string Descricao, double Preco, DateTime Data_da_validade, int Categoria, Produto produto)
        {
            var produto1 = await _context.Produtos.FindAsync(Nome);

            if (Nome == null)
            {
                return NotFound();
            }

            // Não inserir se já existir e se não retornar nulo
            if (produto1 != null)
            {
                if (Nome == produto1.Nome)
                {
                    return BadRequest();
                }

            }

            produto.Nome = Nome;
            produto.Descricao = Descricao;
            produto.Preco = Preco;
            produto.Data_da_validade = Data_da_validade;
            produto.Categoria = Categoria;

            // Inserção de Item
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetProduto", new { nome = produto.Nome}, produto);
        }

        private bool ProdutoExists(string nome)
        {
            return _context.Produtos.Any(e => e.Nome == nome);
        }

    }
}
