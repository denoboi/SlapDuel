using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    //buna playercontroller'da ulasmak icin public yaptik asagida da metod olusturduk.
    public Animator Animator => _animator == null ? _animator = GetComponent<Animator>() : _animator;

    private Stamina _stamina;
    
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }

    public void TriggerAnimation(string ID)
    {
        Animator.SetTrigger(ID);
    }

    private void Update()
    {
       if( Stamina == null)
            return;
        Animator.SetFloat("Stamina", Stamina.CurrentStamina); //mert 
    }

    public void BoolAnimation(string ID, bool value)
    {
        Animator.SetBool(ID, value);
    }

   public void FloatAnimation(string ID, float value)
    {
        Animator.SetFloat(ID, value);
    }
    
}
