using HeroAbilities;
using UnityEngine;

namespace SpecialAbilities
{
    public class BackfireAbility : HeroSpecialAbility
    {
        /// <summary>
        /// Shoots in the hero's oposite slash direction
        /// </summary>
        [SerializeField] private float backFireVelocity;

        // private ObjectsPool shotsPool;

        private void Awake()
        {
            // shotsPool = GetComponent<ObjectsPool>();
        }

        private void Start()
        {
            // shotsPool.SetParentToNull();
        }

        internal override void InitializeAbility()
        {
            // heroSlash = GetComponentInParent<HeroSlash>();
            // heroSlash.IsSlashing.OnChanged += OnSlashingChanged;
            transform.localPosition = Vector3.zero;
        }

        private void OnDisable()
        {
            // if (heroSlash)
            // {
            //     heroSlash.IsSlashing.OnChanged -= OnSlashingChanged;
            // }
        }
        // private void OnSlashingChanged(Observable<bool> arg1, bool oldValue, bool value)
        // {
        //     if (value)
        //     {
        //         Backfire(heroSlash.SlashDirection);
        //     }
        // }
        internal override void ApplyDuplicateEffects()
        {
            Debug.Log("HERE THE BACKFIRE SHOT SHOULD GET BETTER");
        }

        private void Backfire(Vector2 slashDirection)
        {
            // GameObject shot = shotsPool.GetNextPoolObject();
            //
            // shot.transform.position = transform.position;
            //
            // shot.GetComponent<Rigidbody2D>().velocity = -slashDirection.normalized * backFireVelocity;
        }
    }
}
