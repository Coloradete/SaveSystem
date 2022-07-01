using System.Linq;
using UnityEngine;

namespace HeroAbilities
{
    public static class AbilitiesHolder
    {
        public enum AbilityTypes
        {
            HighTechWatts,
            Aerodynamics,
            Spikes,
            Backfire,
            DriveBy,
            Overthrust,
            RubberBullet,
            ThiccShot,
            C4,
            ValiumClaws,
            MagicShell,
            ClockworkNova,
            Curse,
            HolyCrusader,
            CheesyPrayer,
            Vampirism,
            HardLanding,
            TimeFalls
        }

        private static GameObject[] loadedAbilitiesObjects;
        public static GameObject[] AbilitiesObjects; //Ordered by Enum

        private static GameObject[] loadedAbilities;
        public static GameObject[] Abilities; //Ordered by Enum
        static AbilitiesHolder()
        {
            loadedAbilitiesObjects = Resources.LoadAll("AbilitiesObjects").Cast<GameObject>().ToArray();
            AbilitiesObjects = new GameObject[System.Enum.GetValues(typeof(AbilityTypes)).Length];

            loadedAbilities = Resources.LoadAll("Abilities").Cast<GameObject>().ToArray();
            Abilities = new GameObject[System.Enum.GetValues(typeof(AbilityTypes)).Length];

            string abilityName;

            for (int i = 0; i < loadedAbilitiesObjects.Length; i++)
            {
                abilityName = loadedAbilitiesObjects[i].name;
                abilityName = abilityName.Substring(0, abilityName.Length - 6); //Remove the "Object" part

                AbilityTypes abilityType = (AbilityTypes)System.Enum.Parse(typeof(AbilityTypes), abilityName, true);

                AbilitiesObjects[(int)abilityType] = loadedAbilitiesObjects[i]; //Re order the array by Enum

            }
            for (int i = 0; i < loadedAbilities.Length; i++)
            {
                abilityName = loadedAbilities[i].name;
                abilityName = abilityName.Substring(0, abilityName.Length - 7); //Remove the "Ability" part

                AbilityTypes abilityType = (AbilityTypes)System.Enum.Parse(typeof(AbilityTypes), abilityName, true);

                Abilities[(int)abilityType] = loadedAbilities[i]; //Re order the array by Enum
            }
        }
    }
}

