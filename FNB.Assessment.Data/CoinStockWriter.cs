using Dapper;
using FNB.Assessment.Services.Api.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.Sockets;

namespace FNB.Assessment.Data
{
    public interface ICoinStockWriter
    {
        int Save(CoinStock coinStock);
    }
    public class CoinStockWriter : DataAccesBase, ICoinStockWriter
    {
        public CoinStockWriter() : base()
        {

        }
        public int Save(CoinStock coinStock)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("CoinId", coinStock.CoinId);
                parameters.Add("Available", coinStock.Available);
                return connection.Execute("spInsertOrUpdateCoinStock", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
