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
            GameManager manager = new GameManager();
            Player saverTest = new Player("Erik");
            for (int ii = 0; ii < 19; ii++)
            {
                saverTest.KillRat();
            }
            saverTest.Name = "Erik";
            manager.SavePlayer(saverTest);

        }
        [TestMethod]
        public void LoadTest()
        {
            GameManager manager = new GameManager();
            Player loaderTest = new Player("Erik");
            loaderTest = manager.LoadPlayer("Erik");
            loaderTest.KillRat();
            Assert.IsTrue(loaderTest.GetReport().Status == Status.LevelTwo);
        }
        [TestMethod]
        public void SecondSaveTest()
        {
            GameManager manager = new GameManager();
            Player saverTest = new Player("Erik");
            for (int ii = 0; ii < 19; ii++)
            {
                saverTest.KillRat();
            }
            saverTest.Name = "John";
            manager.SavePlayer(saverTest);
            var saverTestTwo = manager.LoadPlayer("John");
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
        public void testRandomPlayerALotOfTimes()
        {
            GameManager manager = new GameManager();
            for (int ii = 0; ii < 100; ii++)
            {
                Player randomTwo = this.RandomPlayer();
                manager.SavePlayer(randomTwo);
            }
        }
        [TestMethod]
        public void CheckingFiles()
        {
            GameManager files = new GameManager();
            files.LoadAllPlayers();
        }
        [TestMethod]
        public void FilesDeleted()
        {
            GameManager delete = new GameManager();
            delete.DeleteAllData();
        }
        [TestMethod]
        public void CheckPlayerExistence()
        {
            GameManager manager = new GameManager();
            Player saverTest = new Player("Erik");
            saverTest.Name = "Erik";
            manager.SavePlayer(saverTest);
            manager.LoadAllPlayers();
            Assert.IsTrue(manager.DoesPlayerExist("Erik"));
            var newPlayer = manager.GetPlayer("Erik");
            Assert.IsNotNull(newPlayer);
            Assert.IsTrue(newPlayer.GetReport().Status == saverTest.GetReport().Status);
        }
        
    }
}
