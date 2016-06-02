using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using MyGameyThing;

namespace TesterWester
{
    [TestClass]
    public class TestingClass
    {
        [TestMethod]
        public void DeathTest()
        {
            Player firstTest = new Player();
            for(int ii = 0; ii<19; ii++)
            {
                firstTest.KillRat();
            }
            firstTest.KillSkeleton();
            Assert.IsTrue(firstTest.GetReport().Status == Status.Dead);
        }
    }
}
