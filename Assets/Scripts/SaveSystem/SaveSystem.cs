using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveSystem
{
    public static class SaveSystem
    {
        public static void SaveHeroes(List<GameObject> heroesList)
        {
            foreach (GameObject hero in heroesList)
            {
                BinaryFormatter formatter = new BinaryFormatter(); //TODO: Simple codifying, it should be done in a safer way
            
                string path = Application.persistentDataPath + 
                              "/heroTestData_" + hero.GetComponent<HeroStatus>().PlayerID + ".explorer";
            
                FileStream stream = new FileStream(path, FileMode.Create);

                HeroData heroData = new HeroData(hero);

                formatter.Serialize(stream, heroData);
            
                stream.Close();
            }
        }
    
        public static HeroData LoadHeroByID(int playerID)
        {
            string path = Application.persistentDataPath + 
                          "/heroTestData_" + playerID + ".explorer";
        
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
    
                HeroData heroData = formatter.Deserialize(stream) as HeroData;
                stream.Close();

                return heroData;
            }
        
            Debug.LogError("FILE DIDN'T EXIST");
            return null;
        }
    
        public static void DeleteHeroesData()
        {
            for (int i = 0; i <= 2; i++)
            {
                string path = Application.persistentDataPath + 
                              "/heroTestData_" + i + ".explorer";
            
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }


        public static void SaveGameData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + GameData.savePath;
            FileStream stream = new FileStream(path, FileMode.Create);
    
            GameData data = new GameData();
    
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static GameData LoadGameData()
        {
            string path = Application.persistentDataPath + GameData.savePath;
    
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
    
                GameData gameData = formatter.Deserialize(stream) as GameData;
                stream.Close();
    
                return gameData;
            }
            else
            {
                Debug.LogError("THERE IS NO GAME DATA");
                return null;
            }
        }

        public static void DeleteGameData()
        {
            string path =  Application.persistentDataPath + GameData.savePath;
        
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
