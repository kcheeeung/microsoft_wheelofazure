using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Wheel_of_Azure;


namespace UnitTests_Player
{
    public class XUnitWheelTest
    {
        [Fact]
        public void TestWheelDollarValues()
        {
            Wheel wheel = new Wheel();
            List<int> dollarValues = new List<int>() { 2500,
                600,
                700,
                600,
                650,
                500,
                700,
                0,
                0,
                0,
                0,
                0,
                600,
                550,
                500,
                600,
                650,
                700,
                800,
                500,
                800,
                500,
                650,
                500 };
            int PrizeAmount = wheel.WheelSpin();
            Assert.Contains(PrizeAmount, dollarValues);
        }


    }
}
