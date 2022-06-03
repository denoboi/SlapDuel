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

    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }
   
    public LaneRunner LaneRunner { get { return _laneRunner == null ? GetComponent<LaneRunner>() : _laneRunner;} } //bu da oluyor farkini sor.
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }
    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }

    private bool _isRegenerated;

    public bool IsTriggered { get; set; }
    public bool IsControlable;

    private void OnEnable()
    {
        Events.OnAIDie.AddListener(OnAiDie); 
    }

   

    private void OnDisable()
    {
        Events.OnAIDie.RemoveListener(OnAiDie);
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
        AnimationController.TriggerAnimation("Run");
    }

    private void Stop()
    {
        if (!IsTriggered)
            return;
            LaneRunner.follow = false;
            AnimationController.TriggerAnimation("Idle");


            if (Input.GetMouseButton(0))
            {
                AnimationController.BoolAnimation("Slap", true);
                Stamina.StaminaDrain();
                
                _isRegenerated = false;

            }
            if (Input.GetMouseButtonUp(0))
            {
                AnimationController.BoolAnimation("Slap", false);
                _isRegenerated = true;
            }


    }

    private void OnAiDie()
    {
        Invoke("OnAiDie", 2);
        IsTriggered = false;
        
    }















}
