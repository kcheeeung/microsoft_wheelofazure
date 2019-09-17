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
        public void TestingMethod1()
        {
            Wheel wheel = new Wheel();
            List<int> dollarValues = new List<int>() { 1, 2, 3 };
            int PrizeAmount = wheel.WheelSpin();
            Assert.Contains(PrizeAmount, dollarValues);
        }
    }
}
