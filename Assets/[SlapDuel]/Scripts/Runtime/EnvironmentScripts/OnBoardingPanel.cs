using HCB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCB.IncrimantalIdleSystem;
using HCB.UI;
using System;

public class OnBoardingPanel : HCBPanel
{

    public HCBPanel ShowUpgradePanel;

 

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        SceneController.Instance.OnSceneLoaded.AddListener(ShowOnboarding);
        EventManager.OnStatUpdated.AddListener(CompleteOnboarding);
    }

  

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        SceneController.Instance.OnSceneLoaded.RemoveListener(ShowOnboarding);
        EventManager.OnStatUpdated.RemoveListener(CompleteOnboarding);
    }

    private void CompleteOnboarding(string arg0)
    {
        ShowUpgradePanel.HidePanel();
        PlayerPrefs.SetInt("OnboardingComplete", 1);
    }


    private bool OnboardingComplete { get { return (PlayerPrefs.GetInt("OnboardingComplete", 0) == 1) ? true : false; } }

    private void ShowOnboarding()
    {
        if (OnboardingComplete)
        {
            HidePanel();
            return;
        }

        ShowPanel();

        if (GameManager.Instance.PlayerData.CurrencyData[HCB.ExchangeType.Coin] == 0)
        {
            HidePanel();
            //HCBPanelList.HCBPanels[HCBPanelList.UpgradePanel].HidePanel();
            return;
        }

       
            if (GameManager.Instance.PlayerData.CurrencyData[HCB.ExchangeType.Coin] >= 6)
            {
                //HCBPanelList.HCBPanels[HCBPanelList.UpgradePanel].ShowPanel();
                ShowUpgradePanel.ShowPanel();
                return;
            }

        HidePanel();
    }

        
  

}
