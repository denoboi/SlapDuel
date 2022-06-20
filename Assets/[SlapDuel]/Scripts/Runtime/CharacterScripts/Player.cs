using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //static yapip instance yap
{

    public SkinnedMeshRenderer _playerMat;
    private Stamina _stamina;

    private float _normalizeStamina;

   



    
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }

    [SerializeField] private ParticleSystem _sweatingParticle;
    [SerializeField] private float _headChangeSpeed;


   


    private void Update()
    {
        TiredMaterial();
    }


    void TiredMaterial()
    {
   
        _normalizeStamina = NormalizeValue(Stamina.CurrentStamina, 0, Stamina.MaxStamina); // bunu tam anlamadim

        _playerMat.material.SetFloat("_Postion", _normalizeStamina);

        if(Stamina.CurrentStamina < 10)
        {
            Sweat();

            _playerMat.SetBlendShapeWeight(0, Mathf.Clamp(Mathf.Sin(Time.time * _headChangeSpeed) * 100, 20, 100));

        }
        else
        {
            StopSweat();
            _playerMat.SetBlendShapeWeight(0, Mathf.Lerp(_playerMat.GetBlendShapeWeight(0), 0, Time.deltaTime * _headChangeSpeed)); //default head size is 80
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

  
}