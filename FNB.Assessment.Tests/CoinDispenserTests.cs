using FNB.Assessment.Services.Api;
using Xunit;

namespace FNB.Assessment.Tests
{
    [TestClass]
    public class CoinDispenserTests
    {
        private readonly ICoinDispenserService _service;
        private readonly int[] _denominations = { 500, 200, 100, 50, 20, 10, 5 };
        public CoinDispenserTests(ICoinDispenserService coinDispenserService)
        {
            _service = coinDispenserService;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1.50)]
        public void GetMinimumCoins_NonPositiveAmount_ThrowsArgumentException(decimal amount)
        {
            Assert.ThrowsException<ArgumentException>(() => _service.GetMinimumCoins(amount, _denominations));
        }

        [Theory]
        [InlineData(1.23)] // Not a multiple of 5 cents
        [InlineData(2.222)]
        public void GetMinimumCoins_InvalidCentAmount_ThrowsArgumentException(decimal amount)
        {
            Assert.ThrowsException<ArgumentException>(() => _service.GetMinimumCoins(amount, _denominations));
        }
    }
}