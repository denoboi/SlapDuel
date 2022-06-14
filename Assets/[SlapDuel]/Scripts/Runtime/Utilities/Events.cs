using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Events
{
    //Use this event manager for your custom ingame events.

    public static UnityEvent OnAIDie = new UnityEvent();
    public static UnityEvent OnAITriggered = new UnityEvent();
    public static UnityEvent OnPlayerSlapping = new UnityEvent();
    public static UnityEvent OnStaminaLow = new UnityEvent();
    public static UnityEvent OnStaminaNormal = new UnityEvent();
    public static UnityEvent OnMoneyEarned = new UnityEvent();
    public static UnityEvent OnPlayerDie = new UnityEvent();


}
