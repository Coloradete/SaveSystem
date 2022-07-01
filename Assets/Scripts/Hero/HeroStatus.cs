using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatus : MonoBehaviour
{
    [Header("Modifying this value could result in the system not working, \n in the future this should get auto assigned")]
    [SerializeField] private int playerID;
    public int PlayerID => playerID;

    [SerializeField] private int currentRegularHealthPoints;
    public int CurrentRegularHealthPoints => currentRegularHealthPoints;
    [SerializeField] private int currentShieldPoints;
    public int CurrentShieldPoints => currentShieldPoints;

    [SerializeField] private bool isDead;
    public bool IsDead => isDead;
}
