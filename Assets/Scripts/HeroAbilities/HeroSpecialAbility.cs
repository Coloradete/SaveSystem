using System;
using UnityEngine;
using static HeroAbilities.AbilitiesHolder;

namespace HeroAbilities
{
    public abstract class HeroSpecialAbility : MonoBehaviour
    {
        [SerializeField] private AbilityTypes abilityType;
        public AbilityTypes AbilityType => abilityType;

        private int abilityLevel;

        public int AbilityLevel => abilityLevel;
        
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
                        heroSpecialAbility.abilityLevel++;
                    }
                }

                Destroy(gameObject);
            }
            else
            {
                abilityLevel++;
                InitializeAbility();
                transform.localPosition = Vector3.zero;
            }
        }

        internal abstract void InitializeAbility();
        internal abstract void ApplyDuplicateEffects();

        private void OnDestroy()
        {
            // if (TryGetComponent(out ObjectsPool objectsPool))
            // {
            //     objectsPool.DestroyPoolObjects();
            // }
        }
    }
}