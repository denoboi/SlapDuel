using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectorAnimationController : MonoBehaviour
{
    private Animator _animator;
    private SphereCollider _sphereCollider;
   
    public Animator Animator => _animator == null ? _animator = GetComponent<Animator>() : _animator;
    public SphereCollider SphereCollider { get { return _sphereCollider == null ? _sphereCollider = GetComponentInChildren<SphereCollider>() : _sphereCollider; } }

    private void Awake()
    {
        SphereCollider.enabled = false;
    }
    public void StartHit()
    {
        SphereCollider.enabled = true;
        
    }

    public void StopHit()
    {
        SphereCollider.enabled = false;
    }

    
}
