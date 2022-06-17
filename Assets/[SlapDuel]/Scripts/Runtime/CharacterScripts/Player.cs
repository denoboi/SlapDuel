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

    

    private void Update()
    {
        TiredMaterial();
    }


    void TiredMaterial()
    {
   
        _normalizeStamina = NormalizeValue(Stamina.CurrentStamina, 0, Stamina.MaxStamina); // bunu tam anlamadim

        _playerMat.materials[1].SetFloat("_Postion", _normalizeStamina);

        if(Stamina.CurrentStamina < 10)
        {
            Sweat();
        }
        else
        {
            StopSweat();
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