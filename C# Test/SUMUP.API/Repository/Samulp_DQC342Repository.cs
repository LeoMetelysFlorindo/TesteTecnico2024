using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUMUP.API.Models;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using System.Globalization;
using System.Threading;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
using System.Data;

namespace SUMUP.API.Repository
{
    public class Samulp_DQC342Repository : ISamulp_DQC342Repository
    {
        private readonly string _connectionString;
        public Samulp_DQC342Repository(string connectionString)
        {
            _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
        }

        public async Task<Users> GetLogin (string username, string password)
        {
            List<Users> usuarios = new List<Users>();
            usuarios.Add(new Users()
            {
                Username = "NKG_Taiwan",
                Password = "NGK@2505_21",
                Role = "manager"
            });

            //int x = 0;

            return usuarios.FirstOrDefault();
            //return usuarios.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }


        // 16/09/2024 14:49h
        // Leonardo Metelis
        // Chamada de pesquisa por NOME  na tabela Produyo
        // GET api/SN/CARRO
        public async Task<IEnumerable<Produto>> GetSN(string nome)
        {
            using (MySqlConnection  connection = new MySqlConnection(_connectionString))
            {
                var query = "SELECT * FROM PRODUTO WHERE NOME = '" + nome + "' ORDER BY NOME";

                using (var dbConnection = new MySqlConnection(_connectionString))
                {
                    return dbConnection.Query<Produto>(query).ToList();
                }

            }

        }

        // 16/09/2024 18:55h
        // Leonardo Metelis
        // Chamada de pesquisa por NOME  na tabela Produyo
        // GET api/descricao/
        public async Task<IEnumerable<Produto>> GetDESCRICAO(string descricao)
        {
            char C = Convert.ToChar(37);

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var query = "SELECT * FROM PRODUTO WHERE DESCRICAO LIKE '" + descricao + C.ToString() + "' ORDER BY NOME";

                using (var dbConnection = new MySqlConnection(_connectionString))
                {
                    return dbConnection.Query<Produto>(query).ToList();
                }

            }

        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var query = "SELECT * FROM PRODUTO ORDER BY NOME";

                using (var dbConnection = new MySqlConnection(_connectionString))
                {
                    return dbConnection.Query<Produto>(query).ToList();
                }

            }

        }

        

    }
}
