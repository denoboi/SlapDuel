using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator _animator;

    //buna playercontroller'da ulasmak icin public yaptik asagida da metod olusturduk.
    public Animator Animator => _animator == null ? _animator = GetComponent<Animator>() : _animator;



    public void TriggerAnimation(string ID)
    {
        Animator.SetTrigger(ID);
    }
}