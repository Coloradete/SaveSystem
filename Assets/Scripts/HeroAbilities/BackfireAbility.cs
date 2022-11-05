using UnityEngine;

namespace HeroAbilities
{
    public class BackfireAbility : HeroSpecialAbility
    {
        /// <summary>
        /// Shoots in the hero's oposite slash direction
        /// </summary>
        [SerializeField] private float backFireVelocity;

        protected override void InitializeAbility()
        {
            transform.localPosition = Vector3.zero;
        }

        protected override void ApplyDuplicateEffects()
        {
            Debug.Log("Backfire upgraded");
        }
    }
}
