using SUMUP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUMUP.API.Repository
{
    interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> DeletaProduto(string nome);  // Deletar um Produto

    }
}
