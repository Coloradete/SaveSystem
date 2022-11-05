using UnityEngine;

namespace HeroAbilities
{
    public class LateralShotsAbility : HeroSpecialAbility
    {
        /// <summary>
        /// Shoots in the hero's oposite slash direction
        /// </summary>
        [SerializeField] private float shotsVelocity;
        
        protected override void InitializeAbility()
        {
            transform.localPosition = Vector3.zero;
        }
        protected override void ApplyDuplicateEffects()
        {
            Debug.Log("Lateralshots upgraded");
        }

    }
}