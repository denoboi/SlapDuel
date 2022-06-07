using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _healthBar;
    public float CurrentHealthPlayer;
    public float CurrentHealthEnemy;
    private float _maxHealth = 100f;

    private PlayerController _playerController;
    private AIController _aiController;

    public PlayerController PlayerController { get { return _playerController == null ? _playerController = GetComponentInParent<PlayerController>() : _playerController; } }
    public AIController AIController { get { return _aiController == null ? _aiController = GetComponentInParent<AIController>() : _aiController; } }


    private void Start()
    {
       _healthBar = GetComponent<Image>();

    }

    private void Update()
    {

        CurrentHealthPlayer = PlayerController.Health.CurrentHealth;
        _healthBar.fillAmount = CurrentHealthPlayer / _maxHealth;
       
    }



}
