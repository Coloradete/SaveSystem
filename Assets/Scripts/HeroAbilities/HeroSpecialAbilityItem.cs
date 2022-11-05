using System;
using HeroAbilities;
using UnityEngine;

namespace SpecialAbilities
{
    public class HeroSpecialAbilityItem : MonoBehaviour
    {
        [Header("The name of the GameObject has to match the AbilityType field" +
                "/n followed by the word Object")]
        [SerializeField] private GameObject abilityGameObject;

        public Type AbilityType { get; private set; }

        public delegate void AbilityGathered(AbilitiesHolder.AbilityTypes abilityType);
        public static event AbilityGathered AbilityGatheredRelease;

        private int assignedPlayerID;

        private void Awake()
        {
            abilityGameObject = Instantiate(abilityGameObject, null);
            abilityGameObject.SetActive(false);

            AbilityType = abilityGameObject.GetComponent<HeroSpecialAbility>().GetType();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out HeroStatus heroStatus))
            {
                if (heroStatus.PlayerID == assignedPlayerID) //The player assigned to gather this ability
                {
                    AbilityGatheredRelease?.Invoke(abilityGameObject.GetComponent<HeroSpecialAbility>().AbilityType);

                    abilityGameObject.transform.SetParent(collision.transform);

                    abilityGameObject.SetActive(true);

                    abilityGameObject.GetComponent<HeroSpecialAbility>().CheckForDuplicates();

                    gameObject.SetActive(false);
                    
                }
            }
        }

        public void TestGetObject(HeroStatus heroStatus)
        {
            GameObject testAbilityGameObject = Instantiate(abilityGameObject, heroStatus.transform);
            testAbilityGameObject.SetActive(true);
            testAbilityGameObject.GetComponent<HeroSpecialAbility>().CheckForDuplicates();
        }

        public void AssignPlayerID(int id)
        {
            assignedPlayerID = id;
        }
    }
}
