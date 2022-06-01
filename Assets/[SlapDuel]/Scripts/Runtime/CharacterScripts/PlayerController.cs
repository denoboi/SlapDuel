using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;
using HCB.Core;

public class PlayerController : MonoBehaviour
{
   
    private LaneRunner _laneRunner;
    private AnimationController _animationController;
    private Stamina _stamina;
    
    
    
    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }
   
    public LaneRunner LaneRunner { get { return _laneRunner == null ? GetComponent<LaneRunner>() : _laneRunner;} } //bu da oluyor farkini sor.
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }
    

    private bool _isSlapping;

    public bool IsTriggered;
    public bool IsControlable;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        if (!LevelManager.Instance.IsLevelStarted)
             return;
        Move();
        Stop();
    }


    private void Move()
    {
        if (_isSlapping)
            return;
        if (IsTriggered)
            return;
        LaneRunner.follow = true;
        AnimationController.TriggerAnimation("Run");
    }

    private void Stop()
    {
        if(IsTriggered)
        {
            LaneRunner.follow = false;
            AnimationController.TriggerAnimation("Idle");

            if (Input.GetMouseButtonDown(0))
                AnimationController.TriggerAnimation("Slap");

            if (Input.GetMouseButton(0))
            {
                Stamina.StaminaDrain();
                
            }
            if(Input.GetMouseButtonUp(0))
            {
                Stamina.StaminaRegen();
            }
        }
    }

    












}
