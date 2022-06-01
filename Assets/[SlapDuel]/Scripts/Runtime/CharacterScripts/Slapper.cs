using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slapper : MonoBehaviour
{
    private AIController _aiController;

    public AIController AIController { get { return _aiController == null ? _aiController = GetComponentInParent<AIController>() : _aiController; } }
   
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponentInParent<Health>(); //Bizim karakterdeki slapper digerinin health'ini aliyor. Diger karakterdeki slapper'da bizim health'i gorecek.
        AIController aIController = other.GetComponentInParent<AIController>();
        PlayerController playerController = GetComponentInParent<PlayerController>();

        if(Input.GetMouseButton(0))
        {
            health.HealthDrain();
            Debug.Log("Health -: " + gameObject.name);
            playerController.IsEnemysTurn = false;
            AIController.StopSlapping();
            
        }
        if (playerController.IsEnemysTurn)
        {
            
            aIController.Slapping();
            
            health.HealthDrain();
            
            Debug.Log("Enemy's Turn");

            
        }
        
    }
}
