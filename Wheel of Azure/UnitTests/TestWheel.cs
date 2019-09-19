using System;
using System.Collections.Generic;
using Wheel_of_Azure;
using Xunit;

namespace UnitTests_Wheel
{
    public class XUnitWheelTest
    {
        [Fact]
        public void TestWheel()
        {
            Wheel wheel = new Wheel();
            HashSet<int> ValuesInWheel = new HashSet<int>();
            foreach (int i in wheel.WheelOfAzure)
            {
                ValuesInWheel.Add(i);
            }

            for (int i = 0; i < 50; i++)
            {
                bool res = ValuesInWheel.Contains(wheel.WheelSpin());
                Assert.True(res);
            }
        }
    }
}
