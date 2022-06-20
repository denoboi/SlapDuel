using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //static yapip instance yap
{

    public SkinnedMeshRenderer _playerMat;
    private Stamina _stamina;

    private float _normalizeStamina;

    private Health _health;


    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }
    
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }

    [SerializeField] private ParticleSystem _sweatingParticle;
    [SerializeField] private float _headChangeSpeed;
    [SerializeField] private ParticleSystem _upgradeParticle;

    private void OnEnable()
    {
        Events.OnPlayerDie.AddListener(StopSweat);
        EventManager.OnStatUpdated.AddListener(UpgradeUIParticle);
    }

    private void OnDisable()
    {
        Events.OnPlayerDie.RemoveListener(StopSweat);
        EventManager.OnStatUpdated.RemoveListener(UpgradeUIParticle);

    }



    private void Update()
    {
        TiredMaterial();
    }


    void TiredMaterial()
    {
   
        _normalizeStamina = NormalizeValue(Stamina.CurrentStamina, 0, Stamina.MaxStamina); // bunu tam anlamadim

        _playerMat.materials[1].SetFloat("_Postion", _normalizeStamina);

        if(Stamina.CurrentStamina < 10 && Health.CurrentHealth > 0)
        {

            Sweat();

            _playerMat.SetBlendShapeWeight(0, Mathf.Clamp(Mathf.Sin(Time.time * _headChangeSpeed) * 100, 20, 100));

        }
        else
        {
            StopSweat();
            _playerMat.SetBlendShapeWeight(0, Mathf.Lerp(_playerMat.GetBlendShapeWeight(0), 80, Time.deltaTime * _headChangeSpeed)); //default head size is 80
        }

    }

    private float NormalizeValue(float value, float min, float max)
    {
        float normalizedValue = (value - min) / (max - min);

        value = Mathf.Clamp(value, min, max);

        normalizedValue = Mathf.Clamp(normalizedValue, 0, 1);

        return normalizedValue;
    }

    private void Sweat()
    {
        var emission = _sweatingParticle.emission;
        emission.rateOverTime = 30;
    }

    public void StopSweat()
    {
        var emission = _sweatingParticle.emission;
        emission.rateOverTime = 0;
    }

    public void UpgradeUIParticle(string s)
    {
        _upgradeParticle.Play();
    }

  
}