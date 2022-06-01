using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;

    //buna playercontroller'da ulasmak icin public yaptik asagida da metod olusturduk.
    public Animator Animator => _animator == null ? _animator = GetComponent<Animator>() : _animator;



    public void TriggerAnimation(string ID)
    {
        Animator.SetTrigger(ID);
    }


    public void BoolAnimation(string ID, bool value)
    {
        Animator.SetBool(ID, value);
    }
}
