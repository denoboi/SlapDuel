using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIController : MonoBehaviour
{

    //lokal event olustur. (OnAIdie) //eventlerle git.

    
    public PlayerController PlayerController { get; set; } //mert
   
    private Stamina _stamina;
    private AnimationController _animationController;
    private Health _health;
    private AI _ai;
    private Slapper _slapper;

   

    [SerializeField] private float _recoveryTime;
    private float _lastTakeDamageTime = Mathf.Infinity;

    public bool IsActivated { get; private set;}
    public bool CanPunch { get; set; }
    

   
    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }

    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }
    public Slapper Slapper { get { return _slapper == null ? _slapper = GetComponentInChildren<Slapper>() : _slapper; } } //this is for disable the collider when player hits.

    public AI AI { get { return _ai == null ? _ai = GetComponent<AI>() : _ai; } }  //for ragdoll

    private void OnEnable()
    {
        Health.OnGetDamage.AddListener(OnTakeDamage);
        
    }

    private void OnDisable()
    {
        Health.OnGetDamage.RemoveListener(OnTakeDamage);
    }

    private void Update()
    {
        if (Time.time > _lastTakeDamageTime + _recoveryTime) // && ile ekle.CanPunch'i
        {
            if (CanPunch)
                return;
            Debug.Log("Punch");
            CanPunch = true;
            Slapping();
        }

        else
        {
            if (!CanPunch)
                return;
            CanPunch = false;
            StopSlapping();
           
        }

    }

    private void Slapping()
    {
        
        AnimationController.FloatAnimation("Slap",0.1f);

    }

    private void StopSlapping()
    {
        AnimationController.FloatAnimation("Slap",0f);
    }



    public void Activate() //mami  //bu activate'i ai ilk kez girdiginde kullanabiliriz.
    {
        IsActivated = true;
    }

    private void OnTakeDamage() //mami
    {
        _lastTakeDamageTime = Time.time;
        

        if (Health.CurrentHealth <= 0)
        {

            GetComponent<RagdollController>().EnableRagdollWithForce(Vector3.left, 250);
            //AI Dead animation.
            Events.OnAIDie.Invoke();

        }

    }

}
