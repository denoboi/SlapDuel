using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVisual : MonoBehaviour
{
    private SkinnedMeshRenderer _enemyMat;
    private Health _health;
   


    public SkinnedMeshRenderer SkinnedMeshRenderer { get { return _enemyMat == null ? _enemyMat = GetComponentInChildren<SkinnedMeshRenderer>() : _enemyMat; } }

    [SerializeField] private ParticleSystem[] ParticleSystems;
    
    [SerializeField] ParticleSystem _hitParticle;

    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }


    private Color _startColor = Color.white;
    private Color _endColor = Color.red;


    private void Start()
    {
        ParticleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        Health.OnGetDamage.AddListener(ParticlePlay);
        Events.OnAIDie.AddListener(DeathParticle);
    }

    private void OnDisable()
    {
        Events.OnAIDie.RemoveListener(DeathParticle);
        Health.OnGetDamage.RemoveListener(ParticlePlay);
    }


    public void ChangeSlapColor(float time)
    {
        SkinnedMeshRenderer.materials[1].color = Color.Lerp(SkinnedMeshRenderer.materials[1].color, _endColor, 0.2f);
    }

    public void DeathParticle()
    {
        ParticleSystems[Random.Range(0,ParticleSystems.Length)].Play();
    }

    public void ParticlePlay()
    {
        _hitParticle.Play();
    }
}


