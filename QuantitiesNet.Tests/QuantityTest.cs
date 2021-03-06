using static QuantitiesNet.Dimensions;
using Xunit;

namespace QuantitiesNet.Tests
{
    public class QuantityTest
    {
        [Fact]
        public void TestGasConstant()
        {
            var IdealGasConstant = new Quantity(8.31451e-3, MolarHeatCapacity.dimension);
            var SteamMolarMass = new Quantity(18.015257e-3, MolarMass.dimension);
            var SpecificSteamGasConstant = IdealGasConstant / SteamMolarMass;
            Assert.Equal(SpecificHeatCapacity.dimension, SpecificSteamGasConstant.Dimension);
            Assert.Equal(0.461526, SpecificSteamGasConstant.Scalar, precision: 6);
        }

        [Fact]
        public void TestVelocity()
        {
            var distance = new Quantity(60, Length.dimension);
            var time = new Quantity(3600, Time.dimension);
            var velocity = distance / time;
            Assert.Equal(Velocity.dimension, velocity.Dimension);
            Assert.Equal(0.016667, velocity.Scalar, 6);
        }

        [Fact]
        public void TestAssertDimension()
        {
            var distance = new Quantity(10, Length.dimension);
            var typed = distance.Assert<Length>();
            Assert.IsType<Quantity<Length>>(typed);
            Assert.Equal(Length.dimension, typed.Dimension);
        }

        [Fact]
        public void TestNullComparison()
        {
            var q = new Quantity(10, Length.dimension);
            Assert.True(q != null);
            Assert.True(null != q);
            Assert.False(q == null);
            Assert.False(null == q);
            Assert.True((Quantity)null == null);
            Assert.True(null == (Quantity)null);
            Assert.True((Quantity)null == (Quantity)null);
        }
    }
}
