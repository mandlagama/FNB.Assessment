namespace FNB.Assessment.Services.Api
{
    public interface ICoinDispenserService
    {
        string GetChange(decimal amount, int[] coinDenomination);
        (int minCoins, Dictionary<int, int> coinBreakdown) GetMinimumCoins(decimal amountInRand, int[] coinDenomination);
    }
}
