using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public PlayerController PlayerController { get; set; } //mert
   
    private Stamina _stamina;
    private AnimationController _animationController;
    private Health _health;

    [SerializeField] private float _recoveryTime; 
    public bool IsActivated { get; private set;}
    public bool CanPunch { get; private set; }

    private float _lastTakeDamageTime;
    private bool _isPunching = true;

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
        
            Slapping();

    }

    public void Slapping()
    {
        
        AnimationController.TriggerAnimation("Slap");

       
            AnimationController.TriggerAnimation("Idle");
    }



    public void Activate() //mami  //bu activate'i ai ilk kez girdiginde kullanabiliriz.
    {
        IsActivated = true;
    }

    private void OnTakeDamage()
    {
        _lastTakeDamageTime = Time.time;

    }

}
