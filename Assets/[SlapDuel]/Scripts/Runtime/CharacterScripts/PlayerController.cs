using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SphereCollider _sphereCollider;
    private CharacterManager _characterManager;

    //public AI AI { get { return _ai == null? GetComponent<AI>} }
    public SphereCollider SphereCollider { get { return _sphereCollider == null ? GetComponentInChildren<SphereCollider>() : _sphereCollider; } }
    public CharacterManager CharacterManager { get { return _characterManager == null ? GetComponent<CharacterManager>() : _characterManager; } } 
    

    //private Vector3[] moveDirections = new Vector3[AI.transform.position];

    private void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
    }



    private void Update()
    {
       
        Move();
    }


   



   
}
