﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGameyThing
{

    public enum Status
        {
            LevelOne,
            LevelTwo,
            LevelThree,
            Dead
            
        }

    public class Player
    {

        public string Name { set; get; }
        public int ratsKilled = 0;
        public int skeletonsKilled = 0;
        public Player(string name)
        {
            this.Name = name;
        }
        public void KillRat()
        {
            ratsKilled++;
        }
        public void KillSkeleton()
        {
            skeletonsKilled++;
        }
        public void PlayerDies()
        {
            //Enter some ending code later here.
        }
        private Status GetStatus()
        {
            if (skeletonsKilled >= 20)
            {
                return Status.LevelThree;
            }
            if (ratsKilled >= 20)
            {
                return Status.LevelTwo;
            }
        
            //if (ratsKilled < 20)
            //{
            //    return Status.LevelOne;
            //}
            if (ratsKilled < 20 && skeletonsKilled > 0)
            {
                return Status.Dead;
            }
            else
            {
                return Status.LevelOne;
            }
        }
        public Report GetReport()
        {
            Report report = new Report();
            report.Status = this.GetStatus();

            return report;
        }
        public new string ToString()
        {
            string message = "";
            var x = this.GetReport();
            switch (x.Status)
            {
                case Status.LevelOne:
                    message += "You are level one! You can only kill rats!";
                    break;
                case Status.LevelTwo:
                    message += "You are level two and can now kill skeletons!";
                    break;
                case Status.Dead:
                    message += "You tried to kill an enemy out of you level range. You died.";
                    break;
                case Status.LevelThree:
                    message += "You are level three!";
                    break;
                //case Status.Other:
                //    message += "Not sure what happened. (Other Status)";
                //    break;
                default:
                    message += "Welcome to the game!";
                    break;
            }
            return message;

        }
        public void Save()
        {
            // serialize and desalinize an object
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new ApplicationException("Name cannot be blank."); 
            }
            string jsonText = JsonConvert.SerializeObject(this); // to get text from object
         
            File.WriteAllText(@"C:/MyGameyThingData/" + this.Name + ".json", jsonText); // save
        }
       // var p = Player.Load("Erik");
        public static Player Load(string playerName)
        {
            var jsonText = File.ReadAllText(@"C:/MyGameyThingData/" + playerName + ".json"); // load
            Player model = JsonConvert.DeserializeObject<Player>(jsonText); // to load object from text
            return model;
        }
      
    }
}
