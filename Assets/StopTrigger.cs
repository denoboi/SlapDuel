using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInChildren<PlayerController>();
        player.LaneRunner.follow = false;
        Debug.Log("triggered" + gameObject);
    }
}
