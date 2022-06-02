using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;

public class StopTrigger : MonoBehaviour //canPunch true iken atabilecek hale gelecek  
{
    //son yedigi dayagi tutacak, time.deltatime, recovery time

    //public propert isActivated get private set.


    private AIController _aIController;

    public AIController AIController { get { return _aIController == null ? _aIController = GetComponentInParent<AIController>() : _aIController; } }

    private void OnTriggerEnter(Collider other)
    {
        if (AIController.IsActivated) //mami
            return;

        PlayerController playerController = other.GetComponentInParent<PlayerController>();
       
        if (playerController == null)
            return;
        
        playerController.IsTriggered = true;
        AIController.Activate();


        Debug.Log("triggered" + other.gameObject);

    }
}
