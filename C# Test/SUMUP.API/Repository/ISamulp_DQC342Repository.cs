using SUMUP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SUMUP.API.Repository
{
    public interface ISamulp_DQC342Repository
    {
        Task<Users> GetLogin(string username, string password);  // Para regitrar Login por Token

        Task<IEnumerable<Produto>> GetSN (string nome);  // Pesquisar Produto pelo Nome

        Task<IEnumerable<Produto>> GetDESCRICAO(string descricao);  // Pesquisar Produto pela Descricao

        Task<IEnumerable<Produto>> ListarProdutos();  // Listar todos os Produtos
              


        //Task<IEnumerable<Produto>> DeletarProduto(string nome);  // Deletar um Produto

        //Task<IEnumerable<Produto>> EditarProdutos(string nome);  // Editar um Produto

        //Task<IEnumerable<Produto>> SalvarProduto(string nome);  // Salvar um Produto

    }
}
