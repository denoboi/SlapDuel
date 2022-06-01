using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;
using HCB.Core;

public class PlayerController : MonoBehaviour
{
    private SphereCollider _sphereCollider;
    private LaneRunner _laneRunner;
    private AnimationController _animationController;
    private BoxCollider _boxCollider;
    
    
    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }
    public SphereCollider SphereCollider { get { return _sphereCollider == null ? _sphereCollider = GetComponentInChildren<SphereCollider>() : _sphereCollider; } }
    public LaneRunner LaneRunner { get { return _laneRunner == null ? GetComponent<LaneRunner>() : _laneRunner;} } //bu da oluyor farkini sor.
    public BoxCollider BoxCollider { get { return _boxCollider == null ? _boxCollider = GetComponentInChildren<BoxCollider>() : _boxCollider; } }


    private bool _isSlapping;

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
    }


    private void Move()
    {
        if (_isSlapping)
            return;
        LaneRunner.follow = true;
        AnimationController.TriggerAnimation("Run");
    }

    












}
