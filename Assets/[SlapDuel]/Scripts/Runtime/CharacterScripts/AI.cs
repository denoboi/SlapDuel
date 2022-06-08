using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Collider MainCollider;
    public Collider[] AllColliders;

    private void Awake()
    {
        MainCollider = GetComponent<Collider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
    }


    public void DoRagdoll(bool isRagdoll)
    {
        foreach (var deniz in AllColliders) //tum collider'lari gezecek ve eger ragdoll modundaysak tum hepsinin collider'larini acacak
            deniz.enabled = isRagdoll;

        MainCollider.enabled = !isRagdoll; //ragdoll degilsek sadece maincollider acik kalacak
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;

    }

}


