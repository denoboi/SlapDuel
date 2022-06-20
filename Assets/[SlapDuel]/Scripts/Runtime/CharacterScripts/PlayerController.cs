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
    private Canvas _canvas;


    public Canvas Canvas { get { return _canvas == null ? _canvas = GetComponentInChildren<Canvas>(true) : _canvas; } } //obje kapaliysa da get ediyor true iken

    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }
   
    public LaneRunner LaneRunner { get { return _laneRunner == null ? GetComponent<LaneRunner>() : _laneRunner;} } //bu da oluyor farkini sor.
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }
    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }
    public IncomeManager IncomeManager { get { return _incomeManager == null ? _incomeManager = GetComponent<IncomeManager>() : _incomeManager; } }

    private bool _isRegenerated;

   [SerializeField] public bool IsTriggered { get; set; }
    public bool CanMove { get; private set; }

    public bool IsControlable;
    private bool isTired;
    public bool IsDead { get; private set; }

 

    private void OnEnable()
    {
        Events.OnAIDie.AddListener(OnAiDie);
        Health.PlayerOnGetDamage.AddListener(OnPlayerDie);
        LevelManager.Instance.OnLevelStart.AddListener(CanvasOpen);
    }

    private void OnDisable()
    {
        Events.OnAIDie.RemoveListener(OnAiDie);
        Health.PlayerOnGetDamage.RemoveListener(OnPlayerDie);
        LevelManager.Instance.OnLevelStart.AddListener(CanvasOpen);
    }


    private void Update()
    {
        if (!LevelManager.Instance.IsLevelStarted)
             return;


        Move();
        Stop();
        Slapping();
        StopSlapping();
        Tired();

        if (_isRegenerated)
        Stamina.StaminaRegen();

    }


    private void Move()
    {
        if (CanMove)
            return;
      
        LaneRunner.follow = true;
        AnimationController.FloatAnimation("Speed", 1);
        CanMove = true;

        _isRegenerated = true; //this is new, for the haptic bug

        AnimationController.BoolAnimation("IsSlapping", false);
        
    }

    private void Stop()
    {
        if (!IsTriggered)
            return;


            LaneRunner.follow = false;
            
            CanMove = false;

        AnimationController.FloatAnimation("Speed", 0);
    }


    void Slapping()
    {

        if (!IsTriggered)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isTired)
                return;
            AnimationController.TriggerAnimation("Slap");

            Stamina.StaminaTween(Stamina.CurrentStamina - 17f);
            AnimationController.BoolAnimation("IsSlapping", true);
        }
        

        if (Input.GetMouseButton(0))
        {
  
            Stamina.StaminaDrain();
            Events.OnPlayerSlapping.Invoke();
            _isRegenerated = false;

            AnimationController.BoolAnimation("IsSlapping", true);

        }


    }

    void StopSlapping()
    {

        if (Input.GetMouseButtonUp(0)) //AI olunce elimizi cektigimizi anlamiyor(isTrigger false), o yuzden manuel altta cekiyoruz (slap-false)
        {
            if (CanMove)
                return;

            if (!IsTriggered)
                return;

            AnimationController.TriggerAnimation("Idle");
            _isRegenerated = true;

            AnimationController.BoolAnimation("IsSlapping", false);
        }
    }

    void Tired()
    {
        if (CanMove)
            return;
        
        if (Stamina.CurrentStamina <= 10)
        {
            
            Events.OnStaminaLow.Invoke(); //can vignette
            
            isTired = true;
            AnimationController.TriggerAnimation("Idle");
            HapticManager.Haptic(HapticTypes.RigidImpact);
        }

         if (Stamina.CurrentStamina > 10 && isTired)
         {
            isTired = false;
            Events.OnStaminaNormal.Invoke();
         }
            

    }
 
        IEnumerator OnAiDieCo()
        {
 
            yield return new WaitForSeconds(0.5f);
            IsTriggered = false;
            CanMove = false;

            AnimationController.FloatAnimation("Speed", 1);
        }

        private void OnAiDie()
        {
            CinemachineShake.Instance.ShakeCamera(.6f, 1.5f);
            HapticManager.Haptic(HapticTypes.Success);
            AnimationController.BoolAnimation("IsSlapping", false);
            
            StartCoroutine(OnAiDieCo());
        }

    private void OnPlayerDie()
    {

        HapticManager.Haptic(HapticTypes.Warning);

        if(Health.CurrentHealth <= 0)
        {
            IsDead = true;
            GetComponentInChildren<Canvas>().enabled = false;
            GetComponent<RagdollController>().EnableRagdollWithForce(Vector3.right, 150);
            Events.OnPlayerDie.Invoke(); //from Ai controller, for animation - from Player, for StopSweat
           
            StartCoroutine(WaitForEnd());

        }
     
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(1.2f);
        GameManager.Instance.CompeleteStage(false);
    }

    private void CanvasOpen()
    {
        Canvas.gameObject.SetActive(true);
    }




}
















