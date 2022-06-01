using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    private EnemyAnimationController _EnemyAnimationController;
    private Stamina _stamina;
    
    public EnemyAnimationController EnemyAnimationController { get { return _EnemyAnimationController == null ? _EnemyAnimationController = GetComponent<EnemyAnimationController>() : _EnemyAnimationController; } }

    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }

    private void Update()
    {
        
   
    }

    public void Slapping()
    {
        EnemyAnimationController.BoolAnimation("Slap", true);
    }

    public void StopSlapping()
    {
        EnemyAnimationController.BoolAnimation("Slap", false);
    }


    



}
