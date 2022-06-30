using HeroAbilities;
using UnityEngine;

namespace SpecialAbilities
{
    public class LateralShotsAbility : HeroSpecialAbility
    {
        /// <summary>
        /// Shoots in the hero's oposite slash direction
        /// </summary>
        [SerializeField] private float shotsVelocity;

        // private ObjectsPool shotsPool;
        //
        // private HeroSlash heroSlash;
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
        //         LateralFire(heroSlash.SlashDirection);
        //     }
        // }
        internal override void ApplyDuplicateEffects()
        {
            Debug.Log("HERE THE LATERAL SHOTS SHOULD GET BETTER");
        }

        private void LateralFire(Vector2 slashDirection)
        {
            // GameObject firstShot = shotsPool.GetNextPoolObject();
            // firstShot.transform.position = transform.position;
            // firstShot.GetComponent<Rigidbody2D>().velocity = new Vector2(slashDirection.y, -slashDirection.x).normalized * shotsVelocity;
            //
            // GameObject secondShot = shotsPool.GetNextPoolObject();
            // secondShot.transform.position = transform.position;
            // secondShot.GetComponent<Rigidbody2D>().velocity = new Vector2(-slashDirection.y, slashDirection.x).normalized * shotsVelocity;
        }

    }
}