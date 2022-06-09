using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;
using HCB.Core;
using System;

public class PlayerController : MonoBehaviour
{
   
    private LaneRunner _laneRunner;
    private AnimationController _animationController;
    private Stamina _stamina;
    private Health _health;
    private IncomeManager _incomeManager;

    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }
   
    public LaneRunner LaneRunner { get { return _laneRunner == null ? GetComponent<LaneRunner>() : _laneRunner;} } //bu da oluyor farkini sor.
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }
    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }
    public IncomeManager IncomeManager { get { return _incomeManager == null ? _incomeManager = GetComponent<IncomeManager>() : _incomeManager; } }


    private bool _isRegenerated;

   [SerializeField] public bool IsTriggered { get; set; }
    public bool IsControlable;

    private void OnEnable()
    {
        Events.OnAIDie.AddListener(OnAiDie);
        Health.PlayerOnGetDamage.AddListener(OnPlayerDie);
    }

   

    private void OnDisable()
    {
        Events.OnAIDie.RemoveListener(OnAiDie);
        Health.PlayerOnGetDamage.RemoveListener(OnPlayerDie);
    }


    private void Update()
    {
        if (!LevelManager.Instance.IsLevelStarted)
             return;
        Move();
        Stop();

        if (_isRegenerated)
        Stamina.StaminaRegen();
    }


    private void Move()
    {
        if (IsTriggered)
            return;
        LaneRunner.follow = true;
        AnimationController.FloatAnimation("Speed", 1);
    }

    private void Stop()
    {
        if (!IsTriggered)
            return;

       
            LaneRunner.follow = false;
            AnimationController.FloatAnimation("Speed", 0);
       
       
        if (Input.GetMouseButtonDown(0))
        {
            
            
            
        }


            if (Input.GetMouseButton(0))
            {
                AnimationController.FloatAnimation("Slap", 0.1f);
                Stamina.StaminaDrain();

                Events.OnPlayerSlapping.Invoke();
                

            _isRegenerated = false;

            }
            else if (Input.GetMouseButtonUp(0)) //AI olunce elimizi cektigimizi anlamiyor(isTrigger false), o yuzden manuel altta cekiyoruz (slap-false)
            {
                AnimationController.FloatAnimation("Slap", 0f);
                
                _isRegenerated = true;
            }


    }

    private void OnAiDie()
    {
        StartCoroutine(OnAIDieCo());
    }

    IEnumerator OnAIDieCo()
    {
        yield return new WaitForSeconds(1);
        IsTriggered = false;
        //death animation will be added

    }

    private void OnPlayerDie() // bu ai scriptine yazilip baska bir eventle burada dinlenebilir.
    {
        if(Health.CurrentHealth <= 0)
        {
            //AI controller'dan slap duracak.
            GameManager.Instance.CompeleteStage(false); // yield return ile daha yavas bitirilebilir.
            GetComponent<RagdollController>().EnableRagdollWithForce(Vector3.right, 350);
            GetComponent<CapsuleCollider>().enabled = false;
        }
     
    }















}
