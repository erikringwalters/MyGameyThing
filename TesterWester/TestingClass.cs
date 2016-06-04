using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGameyThing;

namespace TesterWester
{
    [TestClass]
    public class TestingClass
    {
        private Random random;
        [TestMethod]
        public void DeathTest()
        {
            Player firstTest = new Player("Erik");
            for (int ii = 0; ii < 19; ii++)
            {
                firstTest.KillRat();
            }
            firstTest.KillSkeleton();
            Assert.IsTrue(firstTest.GetReport().Status == Status.Dead);
        }

        [TestInitialize]
        public void Setup()
        {
             random = new Random();
        }

        [TestMethod]
        public void LevelTwoTest()
        {
            Player twoTest = new Player("Erik");
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
            Player oneTest = new Player("Erik");
            oneTest.KillRat();
            Assert.IsTrue(oneTest.GetReport().Status == Status.LevelOne);
        }
        [TestMethod]
        public void SecondLevelOneTest()
        {
            Player secondOneTest = new Player("Erik");
            for (int ii = 0; ii < 20; ii++)
            {
                secondOneTest.KillRat();
            }

            Assert.IsFalse(secondOneTest.GetReport().Status == Status.LevelOne);
        }
        [TestMethod]
        public void ThreeTest()
        {
            Player levelThreeTest = new Player("Erik");
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
        [TestMethod]
        public void SaveTest()
        {
            Player saverTest = new Player("Erik");
            for (int ii = 0; ii < 19; ii++)
            {
                saverTest.KillRat();
            }
            saverTest.Name = "Erik";
            saverTest.Save();

        }
        [TestMethod]
        public void LoadTest()
        {
            Player loaderTest = new Player("Erik");
            loaderTest = Player.Load("Erik");
            loaderTest.KillRat();
            Assert.IsTrue(loaderTest.GetReport().Status == Status.LevelTwo);
        }
        [TestMethod]
        public void SecondSaveTest()
        {
            Player saverTest = new Player("Erik");
            for (int ii = 0; ii < 19; ii++)
            {
                saverTest.KillRat();
            }
            saverTest.Name = "John";
            saverTest.Save();
            var saverTestTwo = Player.Load("John");
            Assert.IsTrue(saverTestTwo.GetReport().Status == Status.LevelOne);
            saverTestTwo.KillRat();
            Assert.IsTrue(saverTestTwo.GetReport().Status == Status.LevelTwo);
        }
        private int RandomNumber()
        {
           
            int randomValue = random.Next(1000, 9999);
            return randomValue;
        }
        private Player RandomPlayer()
        {
            var killThisMany = new Random();
            Player killTest = new Player("Player" + RandomNumber());
            int randomValue = killThisMany.Next(0, 40);
            for (int ii = 0; ii < randomValue; ii++)
            {
                killTest.KillRat();
            }
            if (randomValue >= 20)
            {
                randomValue = killThisMany.Next(0, 40);
                for (int ii = 0; ii < randomValue; ii++)
                {
                    killTest.KillSkeleton();
                }
            }
            return killTest;
        }
       
        [TestMethod]
        public void testRandomPlayer()
        {
            Player randomTwo = this.RandomPlayer();
        }
        [TestMethod]
        public void testRandomPlayerTwoHundredTimes()
        {
            for (int ii = 0; ii < 200; ii++)
            {
                Player randomTwo = this.RandomPlayer();
                randomTwo.Save();
            }
        }
    }
}
