using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float CurrentStamina = 100.0f;

    public float MaxStamina = 100.0f;

    [HideInInspector] public bool IsRegenerated;

    [Header("Stamina Regeneration Parameters")]

    [Range(1.25f, 15f)] public float StaminaDrainMultiplier;
    [Range(1.25f, 15f)] public float StaminaRegenMultiplier;

    private PlayerController _playerController;
    private AnimationController _animationController;

    public PlayerController PlayerController { get { return _playerController == null ? _playerController = GetComponent<PlayerController>() : _playerController; } }
    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }

    //private void Awake()
    //{
    //    AnimationController.SetStamina(HCB.Utilities.HCBUtilities.Normalize01(CurrentStamina, MaxStamina));
    //}

    public void StaminaDrain()
    {
        CurrentStamina -= Time.deltaTime * StaminaDrainMultiplier;

        if (CurrentStamina <= 0)
        {
            
            CurrentStamina = 0f;
            
        }

    }

    public void StaminaRegen()
    {
     
        if (CurrentStamina < MaxStamina)
        {
            CurrentStamina += Time.deltaTime * StaminaRegenMultiplier;
            if (CurrentStamina > MaxStamina)
                CurrentStamina = MaxStamina;
        }

    }

}

