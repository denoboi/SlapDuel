using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stamina : MonoBehaviour
{
    [Header("Stamina Main Parameters")]

    [SerializeField] private float _currentStamina = 100f;
    public float CurrentStamina
    {
        get
        {
            return _currentStamina;
        }

        set
        {
            _currentStamina = value < 0 ? 0 : value;
        }
    }

    public float MaxStamina = 100.0f;

    [HideInInspector] public bool IsRegenerated;

    [Header("Stamina Regeneration Parameters")]

    [Range(1.25f, 15f)] public float StaminaDrainMultiplier;
    [Range(1.25f, 15f)] public float StaminaRegenMultiplier;

    private PlayerController _playerController;
    private AnimationController _animationController;
    private string _staminaTweenID;
    private const float STAMINATWEENDURATION = 0.35F;

   

    public PlayerController PlayerController { get { return _playerController == null ? _playerController = GetComponent<PlayerController>() : _playerController; } }
    public AnimationController AnimationController { get { return _animationController == null ? _animationController = GetComponent<AnimationController>() : _animationController; } }


    private void Awake()
    {
        _staminaTweenID = GetInstanceID() + "_staminaTweenID";
    }

    public void StaminaTween(float endValue)
    {
        DOTween.Kill(_staminaTweenID);
        DOTween.To(() => CurrentStamina, x => CurrentStamina = x, endValue, STAMINATWEENDURATION).SetId(_staminaTweenID).SetEase(Ease.Linear);
    }


    public void StaminaDrain()
    {

        if (DOTween.IsTweening(_staminaTweenID))
            return;

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

