using Dapper;
using FNB.Assessment.Services.Api.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FNB.Assessment.Data
{
    public interface ICoinReader
    {
        string GetCoinNameByRandValue(decimal randValue);
        Coin GetCoinByRandValue(decimal randValue);
    }
    public class CoinReader : DataAccesBase, ICoinReader
    {
        public CoinReader() : base()
        {

        }
        public string GetCoinNameByRandValue(decimal randValue)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("RandValue", randValue);
                dynamic ticket = connection.QuerySingle("spGetCoinNameByRandValue", parameters, commandType: CommandType.StoredProcedure);
                return ticket;
            }
        }
        public Coin GetCoinByRandValue(decimal randValue)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("RandValue", randValue);
                dynamic ticket = connection.QuerySingle<Coin>("spGetCoinByRandValue", parameters, commandType: CommandType.StoredProcedure);
                return ticket;
            }
        }
    }
}
