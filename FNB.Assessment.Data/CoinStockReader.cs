using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FNB.Assessment.Data
{
    public interface ICoinStockReader
    {
        long GetAvailableCoinStockByRandValue(string randValue);
        long GetAvailableCoinStockByCoinId(short coinId);
    }
    public class CoinStockReader : DataAccesBase,ICoinStockReader
    {
        public CoinStockReader() : base()
        {

        }
        public long GetAvailableCoinStockByRandValue(string randValue)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("RandValue", randValue);
                dynamic available = connection.QuerySingle("spGetCoinStockByRandValue", parameters, commandType: CommandType.StoredProcedure);
                return available;
            }
        }
        public long GetAvailableCoinStockByCoinId(short coinId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("CoinId", coinId);
                dynamic available = connection.Query<long>("spGetCoinStockByCoinId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return available;
            }
        }
    }
}
