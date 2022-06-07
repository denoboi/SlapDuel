using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Image _healthBar;
    
    public float CurrentHealthEnemy;
    private float _maxHealth = 100f;

  
    private AIController _aiController;

    
    public AIController AIController { get { return _aiController == null ? _aiController = GetComponentInParent<AIController>() : _aiController; } }


    private void Start()
    {
        _healthBar = GetComponent<Image>();

    }

    private void Update()
    {

        CurrentHealthEnemy = AIController.Health.CurrentHealth;
        _healthBar.fillAmount = CurrentHealthEnemy / _maxHealth;

    }
}
