using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slapper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponentInParent<Health>(); //Bizim karakterdeki slapper digerinin health'ini aliyor. Diger karakterdeki slapper'da bizim health'i gorecek.


        if(Input.GetMouseButton(0))
        {
            health.HealthDrain();
            Debug.Log("Health -: " + gameObject.name);
        }
        
    }
}
