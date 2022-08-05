using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static event Action OnGameStart;
    
    public static event Action OnGameWin;
    public static event Action OnGameLose;
    
    public static event Action OnCarCollision;
    
    public static event Action OnFuelEnd;

    public static event Action OnPositiveFuelPicked;
    public static event Action OnNegativeFuelPicked;
    

    public static event Action OnSpeedBoosted;
    
    public static event Action OnCoinPickUp;
    public static event Action OnReachedEnd;
    public static event Action OnNextLevel;
    public static event Action OnCarUpgrade;
    
    
  
    public static void GameStart()
    {
        OnGameStart?.Invoke();
    }

    public static void CarCollision()
    {
        OnCarCollision?.Invoke();
    }

    public static void FuelEnd()
    {
        OnFuelEnd?.Invoke();
    }
    
    public static void SpeedBoosted()
    {
        OnSpeedBoosted?.Invoke();
    }

    public static void CoinPicked()
    {
        OnCoinPickUp?.Invoke();
    }

    public static void ReachedEnd()
    {
        OnReachedEnd?.Invoke();
    }

    public static void GameWin()
    {
        OnGameWin?.Invoke();
    }

   

    public static void GameLose()
    {
        OnGameLose?.Invoke();
    }

    public static void CarUpgrade()
    {
        OnCarUpgrade?.Invoke();
    }

    public static void PositiveFuelPicked()
    {
        OnPositiveFuelPicked?.Invoke();
    }

    public static void NegativeFuelPicked()
    {
        OnNegativeFuelPicked?.Invoke();
    }

    public static void NextLevel()
    {
        OnNextLevel?.Invoke();
    }
}
