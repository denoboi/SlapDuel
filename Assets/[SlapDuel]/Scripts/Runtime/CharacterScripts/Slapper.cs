using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slapper : MonoBehaviour
{
    public Health Health; //mert
   
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponentInParent<Health>();

        if (health == Health)
            return;

          health.HealthDrain();
    }
}
