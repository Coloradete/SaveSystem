using System.Collections;
using UnityEngine;

namespace HeroAbilities
{
    public class MagicShellAbility : HeroSpecialAbility
    {
        [SerializeField] private float invulnerabilityTime, cooldownTime;

        private float remainingInvulnerabilityTime, currentCooldownTime;

        public bool IsInvulnerable { get; private set; }
        
        protected override void ApplyDuplicateEffects()
        {
            Debug.Log("MagicShell upgraded");
        }

        protected override void InitializeAbility()
        {
            currentCooldownTime = cooldownTime;
        }

        private void Update()
        {
            if (!IsInvulnerable)
            {
                currentCooldownTime -= Time.deltaTime;
                if (currentCooldownTime <= 0f)
                {
                    StartCoroutine(ActivateInvulnerability());
                }
            }
        }

        private IEnumerator ActivateInvulnerability()
        {
            IsInvulnerable = true;

            currentCooldownTime = cooldownTime;

            remainingInvulnerabilityTime = invulnerabilityTime;

            while(remainingInvulnerabilityTime > 0f)
            {
                remainingInvulnerabilityTime -= Time.deltaTime;
                yield return null;
            }

            IsInvulnerable = false;
        }
    }

}