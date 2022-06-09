using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnGetDamage = new UnityEvent();
    public UnityEvent PlayerOnGetDamage = new UnityEvent();

    [Header("Health Main Parameters")]
    public float CurrentHealth = 100.0f;

    public float MaxHealth = 100.0f;

    

    [Header("Health Multiplier Parameters")]

    [Range(100f, 1000f)] public float HealthDrainMultiplier;
    public float PlayerPower = 1;

    public void HealthDrain()
    {
        CurrentHealth -= Time.deltaTime * HealthDrainMultiplier * PlayerPower;

        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("EnemyBoom " + gameObject.name) ;
        }

        OnGetDamage.Invoke();
        PlayerOnGetDamage.Invoke();
    }
    
}
