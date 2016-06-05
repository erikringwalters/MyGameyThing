using System;
using System.Collections.Generic;
using System.IO;

namespace MyGameyThing
{

    public class LoadAndDelete
    {
        private Dictionary<string, Player> playerDictionary = new Dictionary<string, Player>();
        
        public void LoadAllPlayers()
        {
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

        }
    }
}
