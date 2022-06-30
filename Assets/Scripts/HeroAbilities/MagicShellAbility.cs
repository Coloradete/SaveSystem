using System.Collections;
using HeroAbilities;
using UnityEngine;

namespace SpecialAbilities
{
    public class MagicShellAbility : HeroSpecialAbility
    {
        [SerializeField] private float invulnerabilityTime, cooldownTime;

        private float remainingInvulnerabilityTime, currentCooldownTime;

        private bool isInvulnerable;

        private SpriteRenderer sprite;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
        }
        internal override void ApplyDuplicateEffects()
        {
            Debug.Log("THE HolyCrusade should GET BETTER HERE");
        }

        internal override void InitializeAbility()
        {
            currentCooldownTime = cooldownTime;
        }

        private void Update()
        {
            if (!isInvulnerable)
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
            sprite.enabled = true;

            isInvulnerable = true;

            currentCooldownTime = cooldownTime;

            remainingInvulnerabilityTime = invulnerabilityTime;

            while(remainingInvulnerabilityTime > 0f)
            {
                // transform.parent.gameObject.layer = Layers.INMUNE_HERO;
                remainingInvulnerabilityTime -= Time.deltaTime;
                yield return null;
            }

            // transform.parent.gameObject.layer = Layers.HERO;

            sprite.enabled = false;

            isInvulnerable = false;
        }
    }

}