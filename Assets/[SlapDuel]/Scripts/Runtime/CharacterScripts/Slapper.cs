using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slapper : MonoBehaviour
{
    public Health Health; //mert
   
    private void OnTriggerEnter(Collider other)
    {
        
        Health health = other.GetComponentInParent<Health>();
        AnimationController animationController = other.GetComponentInParent<AnimationController>();

        if (other.gameObject.layer == 10) //ragdoll ise return
            return;

        if (health == null)
            return;

        if (health == Health)
            return;

           
          health.HealthDrain();
         animationController.TriggerAnimation("Shake");
            Debug.Log("hit :" + other.gameObject.name);
            
       
    }
}
