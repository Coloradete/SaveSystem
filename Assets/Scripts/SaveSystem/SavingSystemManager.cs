using System.Collections.Generic;
using HeroAbilities;
using UnityEngine;

namespace SaveSystem
{
    public class SavingSystemManager : MonoBehaviour
    {
        private List<GameObject> heroes;
        private Dictionary<int, GameObject> heroesByID;

        private void Awake()
        {
            heroes = new List<GameObject>();
            heroesByID = new Dictionary<int, GameObject>();
        
            foreach (var hero in FindObjectsOfType<HeroStatus>())
            {
                heroes.Add(hero.gameObject);
                heroesByID.Add(hero.PlayerID, hero.gameObject);
            }
        }

        public void SaveData()
        {
            Debug.Log("Data was saved");
            SaveSystem.SaveGameData();
            SaveSystem.SaveHeroes(heroes);
        }

        public void LoadGameData()
        {
            GameData gameData = SaveSystem.LoadGameData();
        
            Debug.Log("Loaded game, current level: " + gameData.CurrentLevel);
        }

        public void LoadHeroData(int heroID)
        {
            HeroData heroData = SaveSystem.LoadHeroByID(heroID);
        
            Debug.Log("This data should update the hero parameters, by now just showing it");
            if (heroData != null)
            {
                Debug.Log("Loaded hero with ID " + heroID + 
                          " Hero Regular Health " + heroData.HeroCurrentRegularHealthPoints +
                          " Hero Shield Points " + heroData.HeroCurrentShieldPoints +
                          " Hero is dead: " + heroData.HeroIsDead);

                for (int i = 0; i < heroData.AbilitiesHold.Length; i++)
                {
                    for (int k = 0; k < heroData.AbilitiesHold[i]; k++)
                    {
                        GameObject ability = Instantiate(AbilitiesHolder.Abilities[i] ,heroesByID[heroID].transform);
                        Debug.Log("Hero had ability: " + ability);
                        ability.GetComponent<HeroSpecialAbility>().CheckForDuplicates();
                    }
                }
            }
            else
            {
                Debug.LogError("NO HERO WITH THAT ID SAVED");
            }
        }
    
        public void DeleteData()
        {
            SaveSystem.DeleteHeroesData();
            SaveSystem.DeleteGameData();
            Debug.Log("All the data has been deleted");
        }
    
    }
}
