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
            for (int ii = 0; ii < 19; ii++)
            {
                firstTest.KillRat();
            }
            firstTest.KillSkeleton();
            Assert.IsTrue(firstTest.GetReport().Status == Status.Dead);
        }
        [TestMethod]
        public void LevelTwoTest()
        {
            Player twoTest = new Player();
            for (int ii = 0; ii < 20; ii++)
            {
                twoTest.KillRat();
            }
            twoTest.KillSkeleton();
            Assert.IsTrue(twoTest.GetReport().Status == Status.LevelTwo);
        }   
        [TestMethod]
        public void LevelOneTest()
        {
            Player oneTest = new Player();
            oneTest.KillRat();
            Assert.IsTrue(oneTest.GetReport().Status == Status.LevelOne);
        }
        [TestMethod]
        public void SecondLevelOneTest()
        {
            Player secondOneTest = new Player();
            for (int ii = 0; ii < 20; ii++)
            {
                secondOneTest.KillRat();
            }
           
            Assert.IsFalse(secondOneTest.GetReport().Status == Status.LevelOne);
        }
        [TestMethod]
        public void ThreeTest()
        {
            Player levelThreeTest = new Player();
            for (int ii = 0; ii < 20; ii++)
            {
                levelThreeTest.KillRat();
            }
            for (int ii = 0; ii < 20; ii++)
            {
                levelThreeTest.KillSkeleton();
            }
            Assert.IsTrue(levelThreeTest.GetReport().Status == Status.LevelThree);
        }
        }
}
