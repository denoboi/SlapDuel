using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;

public class StopTrigger : MonoBehaviour //canPunch true iken atabilecek hale gelecek  
{
    //son yedigi dayagi tutacak, time.deltatime, recovery time



    private AIController _aIController;
    

    public AIController AIController { get { return _aIController == null ? _aIController = GetComponentInParent<AIController>() : _aIController; } }
   
  

    private void OnTriggerEnter(Collider other)
    {
        if (AIController.IsActivated) //mami //AI da player'in kendi collider'ina girdigini bilecek
            return;

        PlayerController playerController = other.GetComponentInParent<PlayerController>();
       
        if (playerController == null)
            return;

        AIController.AnimationController.FloatAnimation("Slap", 0.1f);
        
        AIController.Activate();
        playerController.IsTriggered = true;

        
        Debug.Log("triggered" + other.gameObject);

    }
}
