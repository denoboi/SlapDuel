using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNHold : MonoBehaviour
{



    private void OnEnable()
    {
        LevelManager.Instance.OnLevelFinish.AddListener(() => PlayerPrefs.SetInt("TapNHold", 1));
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnLevelFinish.RemoveListener(() => PlayerPrefs.SetInt("TapNHold", 1));
    }


    void Start()
    {
        if (PlayerPrefs.GetInt("TapNHold", 0) > 0)
            Destroy(gameObject);
    }

    

  
}
