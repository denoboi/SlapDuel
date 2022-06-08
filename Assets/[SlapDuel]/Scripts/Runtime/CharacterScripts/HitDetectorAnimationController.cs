using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectorAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Slapper _slapper;
   
    public Animator Animator => _animator == null ? _animator = GetComponent<Animator>() : _animator;
    public Slapper Slapper { get { return _slapper == null ? _slapper = GetComponentInChildren<Slapper>() : _slapper; } }

    private void Awake()
    {
        Slapper.GetComponent<SphereCollider>().enabled = false;
    }
    public void StartHit()
    {
        Slapper.GetComponent<SphereCollider>().enabled = true;
        
        
    }

    public void StopHit()
    {
        Slapper.GetComponent<SphereCollider>().enabled = false;
    }

    
}
