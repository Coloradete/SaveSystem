using System.Collections.Generic;
using HeroAbilities;
using UnityEngine;

namespace SpecialAbilities
{
    public class HeroSpecialAbilityItem : MonoBehaviour
    {
        [Header("followed by the word Object")]
        [Header("The name of the GameObject has to match the AbilityType field")]
        [SerializeField] private GameObject abilityGameObject;

        // public Type AbilityType { get; private set; }

        private List<GameObject> otherAbilitiesChoices;
        public delegate void AbilityGathered(AbilitiesHolder.AbilityTypes abilityType);
        public static event AbilityGathered AbilityGatheredRelease;

        private int assignedPlayerID;

        private void Awake()
        {
            abilityGameObject = Instantiate(abilityGameObject, null);

            abilityGameObject.SetActive(false);

            // AbilityType = abilityGameObject.GetComponent<HeroSpecialAbility>().GetType();

            otherAbilitiesChoices = new List<GameObject>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out HeroStatus heroStatus))
            {
                if (heroStatus.PlayerID == assignedPlayerID)
                {
                    AbilityGatheredRelease?.Invoke(abilityGameObject.GetComponent<HeroSpecialAbility>().AbilityType);

                    abilityGameObject.transform.SetParent(collision.transform);

                    abilityGameObject.SetActive(true);

                    abilityGameObject.GetComponent<HeroSpecialAbility>().CheckForDuplicates();

                    foreach (GameObject item in otherAbilitiesChoices)
                    {
                        item.SetActive(false);
                    }

                    gameObject.SetActive(false);
                    
                }
            }
        }

        public void TestGetObject(HeroStatus heroStatus)
        {
            GameObject testAbilityGameObject = Instantiate(abilityGameObject, null);

            testAbilityGameObject.transform.SetParent(heroStatus.transform);
            
            testAbilityGameObject.GetComponent<HeroSpecialAbility>().CheckForDuplicates();
        }
        
        public void AddOtherAbilityChoice(GameObject item)
        {
            otherAbilitiesChoices.Add(item);
        }

        public void AssignPlayerID(int id)
        {
            assignedPlayerID = id;
        }
    }
}
