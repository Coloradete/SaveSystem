using System;
using TMPro;
using UnityEngine;
using static HeroAbilities.AbilitiesHolder;

namespace HeroAbilities
{
    public abstract class HeroSpecialAbility : MonoBehaviour
    {
        [SerializeField] private AbilityTypes abilityType;
        public AbilityTypes AbilityType => abilityType;
        public int AbilityLevel { get; private set; }

        [SerializeField] protected TMP_Text abilityLevelText;
        public void CheckForDuplicates()
        {
            Type type = GetType();

            Component[] components = transform.parent.GetComponentsInChildren(type);

            if (components.Length > 1)
            {

                for (int i = 0; i < components.Length; i++)
                {
                    if(components[i].gameObject != gameObject)
                    {
                        HeroSpecialAbility heroSpecialAbility = (HeroSpecialAbility)components[i];
                        heroSpecialAbility.ApplyDuplicateEffects();
                        heroSpecialAbility.AbilityLevel++;
                        heroSpecialAbility.abilityLevelText.text = heroSpecialAbility.AbilityLevel.ToString();
                    }
                }

                Destroy(gameObject);
            }
            else
            {
                AbilityLevel++;
                InitializeAbility();
                transform.localPosition = Vector3.zero;
            }
        }

        protected abstract void InitializeAbility();
        protected abstract void ApplyDuplicateEffects();
    }
}