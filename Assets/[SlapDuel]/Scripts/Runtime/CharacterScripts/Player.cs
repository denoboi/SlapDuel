using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SkinnedMeshRenderer _playerMat;
    private Stamina _stamina;

    private float _normalizeStamina;

    public SkinnedMeshRenderer SkinnedMeshRenderer { get { return _playerMat == null ? _playerMat = GetComponentInChildren<SkinnedMeshRenderer>() : _playerMat; } }
    public Stamina Stamina { get { return _stamina == null ? _stamina = GetComponent<Stamina>() : _stamina; } }

    private void Update()
    {
        TiredMaterial();
    }


    void TiredMaterial()
    {
   
        _normalizeStamina = NormalizeValue(Stamina.CurrentStamina, 0, Stamina.MaxStamina); // bunu tam anlamadim

        SkinnedMeshRenderer.material.SetFloat("_Postion", _normalizeStamina);


    }

    private float NormalizeValue(float value, float min, float max)
    {
        float normalizedValue = (value - min) / (max - min);

        value = Mathf.Clamp(value, min, max);

        normalizedValue = Mathf.Clamp(normalizedValue, 0, 1);

        return normalizedValue;
    }
}