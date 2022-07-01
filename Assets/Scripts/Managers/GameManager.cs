using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [Header("This value should be only modified out of play time to be taken into account in the saving process")]
   [SerializeField] private int currentLevelTest;
   private static int currentLevel;
   public static int CurrentLevel => currentLevel;

   private void Awake()
   {
      currentLevel = currentLevelTest;
   }
}
