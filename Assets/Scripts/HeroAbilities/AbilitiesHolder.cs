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

        private static GameObject[] abilitiesObjects;
        public static GameObject[] AbilitiesObjects; //Ordered by Enum

        private static GameObject[] abilities;
        public static GameObject[] Abilities; //Ordered by Enum
        static AbilitiesHolder()
        {
            abilitiesObjects = Resources.LoadAll("AbilitiesObjects").Cast<GameObject>().ToArray();
            AbilitiesObjects = new GameObject[System.Enum.GetValues(typeof(AbilityTypes)).Length];

            abilities = Resources.LoadAll("Abilities").Cast<GameObject>().ToArray();
            Abilities = new GameObject[System.Enum.GetValues(typeof(AbilityTypes)).Length];

            string abilityName;

            for (int i = 0; i < abilitiesObjects.Length; i++)
            {
                abilityName = abilitiesObjects[i].name;
                abilityName = abilityName.Substring(0, abilityName.Length - 6);

                AbilityTypes abilityType = (AbilityTypes)System.Enum.Parse(typeof(AbilityTypes), abilityName, true);

                AbilitiesObjects[(int)abilityType] = abilitiesObjects[i];

            }
            for (int i = 0; i < abilities.Length; i++)
            {
                abilityName = abilities[i].name;
                abilityName = abilityName.Substring(0, abilityName.Length - 7);

                AbilityTypes abilityType = (AbilityTypes)System.Enum.Parse(typeof(AbilityTypes), abilityName, true);

                Abilities[(int)abilityType] = abilities[i];
            }
        }
    }
}

