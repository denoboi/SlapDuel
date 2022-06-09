using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HCB.Core;
using System;

public class MoneyTextController : MonoBehaviour
{
    TextMeshProUGUI _moneyText;

    TextMeshProUGUI MoneyText { get { return _moneyText == null ? _moneyText = GetComponent<TextMeshProUGUI>() : _moneyText; } }

    private void OnEnable()
    {
        Events.OnPlayerSlapping.AddListener(UpdateText);
        SceneController.Instance.OnSceneLoaded.AddListener(UpdateText);
        EventManager.OnPlayerDataChange.AddListener(UpdateText);
        
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        Events.OnPlayerSlapping.RemoveListener(UpdateText);

        SceneController.Instance.OnSceneLoaded.RemoveListener(UpdateText);

        EventManager.OnPlayerDataChange.RemoveListener(UpdateText);
    }


    private void UpdateText()
    {
        MoneyText.text = GameManager.Instance.PlayerData.CurrencyData[HCB.ExchangeType.Coin].ToString("N1");
    }
}
