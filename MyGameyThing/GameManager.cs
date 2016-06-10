using System;
using System.Collections.Generic;
using System.IO;

namespace MyGameyThing
{

    public class GameManager
    {
        public GameManager()
        {
            LoadAllPlayers();
        }
        private Dictionary<string, Player> playerDictionary = new Dictionary<string, Player>();
        public void LoadAllPlayers()
        {
            playerDictionary = new Dictionary<string, Player>();
            string filepath = @"C:/MyGameyThingData/";
            DirectoryInfo d = new DirectoryInfo(filepath);
            foreach (var file in d.GetFiles("*.json"))
            {
                var a = file;
                var fileName = file.Name.Replace(".json", "");
                var player = Player.Load(fileName);
                playerDictionary.Add(fileName, player);
            }
        }
        public void DeleteAllData()
        {
            string filepath = @"C:/MyGameyThingData/";
            DirectoryInfo d = new DirectoryInfo(filepath);
            foreach (var file in d.GetFiles("*.json"))
            {
                file.Delete();
            }
        }
        public bool DoesPlayerExist(string playerName)
        {
            return playerDictionary.ContainsKey(playerName);
        }
        public Player GetPlayer(string playerName)
        {
            if(playerDictionary.ContainsKey(playerName))
            {
                return playerDictionary[playerName];
            }
            else
            {
                return null;
            }
        }
        public void SavePlayer(Player player)
        {
            if(player.IsNew == true)
            {
               if(this.DoesPlayerExist(player.Name))
                {
                    throw new ApplicationException("Player by that name already exists.");
                }
                else
                {
                    playerDictionary.Add(player.Name, player);
                    player.IsNew = false;
                }
            } 
            else // Player is not new
            {
                playerDictionary[player.Name] = player;
            }
            player.Save();
        }
        public Player LoadPlayer(string playerName)
        {
           return Player.Load(playerName);
        }
    }
}
