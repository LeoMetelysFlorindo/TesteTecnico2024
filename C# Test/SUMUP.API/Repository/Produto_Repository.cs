using System.Threading.Tasks;
using SUMUP.API.Models;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using System.Globalization;
using System.Threading;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace SUMUP.API.Repository
{
    public class Produto_Repository : IProdutoRepository
    {
        private readonly string _connectionString;

        public Produto_Repository(string connectionString)
        {
            _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
        }

        public Task<IEnumerable<Produto>> DeletaProduto(string nome)
        {
            throw new System.NotImplementedException();
        }
    }
}
