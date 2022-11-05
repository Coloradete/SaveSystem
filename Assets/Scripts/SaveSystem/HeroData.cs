using HeroAbilities;
using UnityEngine;
using static HeroAbilities.AbilitiesHolder;

namespace SaveSystem
{
    [System.Serializable]
    public class HeroData
    {
        //Status section
        private int heroCurrentRegularHealthPoints;
        private int heroCurrentShieldPoints;
        private bool heroIsDead;

        //Objects section
        private int[] abilitiesHold = new int[System.Enum.GetValues(typeof(AbilityTypes)).Length];

        public int HeroCurrentRegularHealthPoints => heroCurrentRegularHealthPoints;
        public int HeroCurrentShieldPoints => heroCurrentShieldPoints;
        public bool HeroIsDead => heroIsDead;

        public int[] AbilitiesHold => abilitiesHold;

        public HeroData (GameObject hero)
        {
            HeroStatus heroStatus = hero.GetComponent<HeroStatus>();
        
            heroCurrentRegularHealthPoints = heroStatus.CurrentRegularHealthPoints;
            heroCurrentShieldPoints = heroStatus.CurrentShieldPoints;
            heroIsDead = heroStatus.IsDead;

            for (int i = 0; i < hero.transform.childCount; i++)
            {
                if(hero.transform.GetChild(i).TryGetComponent(out HeroSpecialAbility heroSpecialAbility))
                {
                    //Debug.Log(heroSpecialAbility.AbilityType + " " + (int)heroSpecialAbility.AbilityType + " level:"
                    //+ heroSpecialAbility.AbilityLevel); 
                    abilitiesHold[(int)heroSpecialAbility.AbilityType] = heroSpecialAbility.AbilityLevel;
                }
            }
        }
    }
}
