using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HCB.Core;
using System;

public class AIController : MonoBehaviour
{

    //lokal event olustur. (OnAIdie) //eventlerle git.

    
    public PlayerController PlayerController { get; set; } //mert
   
    private Stamina _stamina;
    private AnimationController _animationController;
    private Health _health;
    private AIVisual _ai;
    private Slapper _slapper;
    private IncomeManager _incomeManager;
    

   

    [SerializeField] private float _recoveryTime;
    private float _lastTakeDamageTime = Mathf.Infinity;

    public bool IsActivated { get; private set;}
    public bool CanPunch { get; set; }

    private bool _isDead;
    

   
    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }
   

    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }

   

    public Slapper Slapper { get { return _slapper == null ? _slapper = GetComponentInChildren<Slapper>() : _slapper; } } //this is for disable the collider when player hits.

    public AIVisual AI { get { return _ai == null ? _ai = GetComponent<AIVisual>() : _ai; } }  //for ragdoll

    public IncomeManager IncomeManager { get { return _incomeManager == null ? _incomeManager = GetComponent<IncomeManager>() : _incomeManager; } }


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

    public void Init(float strength)
    {
        Health.HealthDrainMultiplier -= strength;
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
        AnimationController.FloatAnimation("Slap", 0.1f);
    }

    private void OnTakeDamage() //mami
    {
        if (_isDead)
            return;

        _lastTakeDamageTime = Time.time;
        GameManager.Instance.PlayerData.CurrencyData[HCB.ExchangeType.Coin] += (float)IncomeManager.IdleStat.CurrentValue;
        AI.ChangeSlapColor(2);
        HapticManager.Haptic(HapticTypes.SoftImpact);
        Events.OnMoneyEarned.Invoke();

        if (Health.CurrentHealth <= 0)
        {
            
            _isDead = true; //mert
            GetComponentInChildren<Canvas>().enabled = false;
            GetComponent<RagdollController>().EnableRagdollWithForce(Vector3.left, 650);
            

            Events.OnAIDie.Invoke();

        }

    }

}
