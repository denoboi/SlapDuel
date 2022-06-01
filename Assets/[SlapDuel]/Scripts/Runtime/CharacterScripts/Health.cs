using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Main Parameters")]
    public float CurrentHealth = 100.0f;

    public float MaxHealth = 100.0f;

    [Header("Stamina Regeneration Parameters")]

    [Range(10f, 150f)] public float HealthDrainMultiplier;

    public void HealthDrain()
    {
        CurrentHealth -= Time.deltaTime * HealthDrainMultiplier;

        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("EnemyBoom " + gameObject.name) ;
        }
    }
    
}
