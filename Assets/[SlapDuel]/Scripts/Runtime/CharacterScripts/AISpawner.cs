using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour //Bu scripti baska yere de atamisim 1 saat ugrastik mert'le
{

    public GameObject Enemies;
    public GameObject Player;
    private float strength;
    private int _enemyCount;
    private int _enemyLevel = 1;
   

    private void OnEnable()
    {
        Events.OnAIDie.AddListener(InstantiateAI);
    }

    private void OnDisable()
    {
        Events.OnAIDie.RemoveListener(InstantiateAI);
    }

    void InstantiateAI()
    {
        
        Vector3 position = Player.transform.position;
        Vector3 offset = Vector3.forward * Random.Range(6, 12);

        /*Instantiate metodu gameobject donuyor*/
        GameObject enemy = Instantiate(Enemies, position + offset, Enemies.transform.rotation); //quaternion identity yazinca 0'liyor.Su an kendi rotasyonu

        _enemyCount++;

        if(_enemyCount > 10) // mert harikasi
        {
            _enemyCount = 0;
            strength += 400;
            _enemyLevel++;
        }

        //for harder Ai
        enemy.GetComponent<AIController>().Init(strength); //mami
        enemy.GetComponentInChildren<LevelTextController>().SetLevel(_enemyLevel);
    }

}
