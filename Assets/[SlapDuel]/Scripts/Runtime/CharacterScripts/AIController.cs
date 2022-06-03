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
    private CapsuleCollider _capsuleCollider;

    [SerializeField] private float _recoveryTime;
    private float _lastTakeDamageTime = Mathf.Infinity;

    public bool IsActivated { get; private set;}
    public bool CanPunch { get; private set; }
    

    public CapsuleCollider CapsuleCollider { get { return _capsuleCollider == null ? _capsuleCollider = GetComponentInChildren<CapsuleCollider>() : _capsuleCollider; } }
    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }

    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }

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

    public void Slapping()
    {
        
        AnimationController.TriggerAnimation("Slap");

    }

    public void StopSlapping()
    {
        AnimationController.TriggerAnimation("Idle");
    }



    public void Activate() //mami  //bu activate'i ai ilk kez girdiginde kullanabiliriz.
    {
        IsActivated = true;
    }

    private void OnTakeDamage() //mami
    {
        _lastTakeDamageTime = Time.time;
        if(Health.CurrentHealth <= 0)
        {
            //Dead animation.
            Events.OnAIDie.Invoke();
        }

    }

   

}
