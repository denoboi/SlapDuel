using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

   
    private Stamina _stamina;
    private AnimationController _animationController;
    
   

    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }

    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }


    private void Update()
    {
        Slapping();
        StopSlapping();
   
    }

    public void Slapping()
    {
        if(Input.GetMouseButtonUp(0))
       AnimationController.BoolAnimation("Slap", true);
        AnimationController.BoolAnimation("Shake", false);
        
    }

    public void StopSlapping()
    {
        if(Input.GetMouseButton(0))
        AnimationController.BoolAnimation("Slap", false);
        AnimationController.BoolAnimation("Shake", true) ;
    }


    



}
