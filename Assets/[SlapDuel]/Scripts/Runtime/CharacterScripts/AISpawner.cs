using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour //Bu scripti baska yere de atamisim 1 saat ugrastik mert'le
{

    public GameObject Enemy;
    public GameObject Player;
    private float strength;

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
        strength += 50;
        Vector3 position = Player.transform.position;
        Vector3 offset = Vector3.forward * Random.Range(6, 12);

        /*Instantiate metodu gameobject donuyor*/
        GameObject enemy = Instantiate(Enemy, position + offset, Enemy.transform.rotation); //quaternion identity yazinca 0'liyor.Su an kendi rotasyonu

        //for harder Ai
        enemy.GetComponent<AIController>().Init(strength); //mami
    }


}
