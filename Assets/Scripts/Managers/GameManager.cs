using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private int currentLevelTest;
   private static int currentLevel;
   public static int CurrentLevel => currentLevel;

   private void Awake()
   {
      currentLevel = currentLevelTest;
   }
}
