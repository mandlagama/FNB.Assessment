using FNB.Assessment.Data;
using FNB.Assessment.Services.Api;
using FNB.Assessment.Services.Api.Entities;
using System.Text;

namespace FNB.Assessment.Services
{
    public class CoinDispenserService : ICoinDispenserService
    {
        private readonly string CURRENCY_SYMBOL = "R";
        private readonly ICoinStockWriter _coinStockWriter;
        private readonly ICoinStockReader _coinStockReader;
        private readonly ICoinReader _coinReader;
        public CoinDispenserService(ICoinStockWriter coinStockWriter, ICoinStockReader coinStockReader, ICoinReader coinReader)
        {
            _coinStockWriter = coinStockWriter;
            _coinStockReader = coinStockReader;
            _coinReader = coinReader;
        }
        public string GetChange(decimal amount, int[] coinDenomination)
        {
            try
            {
                var (minCoins, breakdown) = GetMinimumCoins(amount, coinDenomination);
                var result = new StringBuilder();
                result.AppendLine($"Change for {CURRENCY_SYMBOL}{amount:F2}:");
                result.AppendLine($"Minimum coins needed: {minCoins}");

                foreach (var kvp in breakdown.OrderByDescending(x => x.Key))
                {
                    decimal coinValue = kvp.Key / 100.0m;
                    var coin = _coinReader.GetCoinByRandValue(coinValue);
                    string coinName = coin.Name;
                    result.AppendLine($"{kvp.Value} x {CURRENCY_SYMBOL}{coinValue:F2} ({coinName})");
                    _coinStockWriter.Save(new CoinStock
                    {
                        CoinId = coin.CoinId,
                        Available = _coinStockReader.GetAvailableCoinStockByCoinId(coin.CoinId) - kvp.Value,
                        ModifiedById = 1,//System user
                        ModifiedOn = DateTime.Now,
                        CreatedOn = coin.CreatedOn,
                    });
                        
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public (int minCoins, Dictionary<int, int> coinBreakdown) GetMinimumCoins(decimal amountInRand, int[] coinDenomination)
        {
            // Convert Rand to cents
            int targetAmount = (int)(amountInRand * 100);

            if (targetAmount <= 0)
                throw new ArgumentException("Amount must be greater than 0");

            if (targetAmount % 5 != 0)
                throw new ArgumentException("Amount must be a multiple of 5 cents");

            // dp[i] represents minimum coins needed for amount i
            int[] dp = new int[targetAmount + 1];
            // Track which coin was used for each amount
            int[] coinUsed = new int[targetAmount + 1];

            // Initialize dp array
            Array.Fill(dp, targetAmount + 1);
            dp[0] = 0;

            // Fill dp array
            for (int i = 5; i <= targetAmount; i += 5) // Step by 5 since smallest coin is 5c
            {
                foreach (int coin in coinDenomination)
                {
                    if (coin <= i)
                    {
                        if (dp[i - coin] + 1 < dp[i])
                        {
                            dp[i] = dp[i - coin] + 1;
                            coinUsed[i] = coin;
                        }
                    }
                }
            }

            if (dp[targetAmount] > targetAmount)
                throw new InvalidOperationException("Cannot make exact change with available coins");

            // Reconstruct the coins used
            var coinBreakdown = new Dictionary<int, int>();
            int remainingAmount = targetAmount;

            while (remainingAmount > 0)
            {
                int coin = coinUsed[remainingAmount];
                coinBreakdown[coin] = coinBreakdown.ContainsKey(coin) ? coinBreakdown[coin] + 1 : 1;
                remainingAmount -= coin;
            }

            return (dp[targetAmount], coinBreakdown);
        }
    }
}
