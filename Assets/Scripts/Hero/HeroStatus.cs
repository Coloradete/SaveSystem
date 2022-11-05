using UnityEngine;

public class HeroStatus : MonoBehaviour
{
    [Header("Modifying the ID value could result in the system not working, " +
            "\n this should get auto assigned by a manager of your choice" +
            "\n probably related to the controller or player account")]
    [SerializeField] private int playerID;
    public int PlayerID => playerID;

    [SerializeField] private int currentRegularHealthPoints;
    public int CurrentRegularHealthPoints => currentRegularHealthPoints;
    [SerializeField] private int currentShieldPoints;
    public int CurrentShieldPoints => currentShieldPoints;

    [SerializeField] private bool isDead;
    public bool IsDead => isDead;
}
