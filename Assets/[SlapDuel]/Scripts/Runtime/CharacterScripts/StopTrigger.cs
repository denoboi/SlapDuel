using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;

public class StopTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        LaneRunner laneRunner = other.GetComponentInParent<LaneRunner>();
        PlayerController playerController = other.GetComponentInParent<PlayerController>();

        if (laneRunner == null)
            return;
        
        playerController.IsTriggered = true;

       
        Debug.Log("triggered" + other.gameObject);

    }
}
