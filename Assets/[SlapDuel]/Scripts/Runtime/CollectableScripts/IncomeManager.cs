using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCB.IncrimantalIdleSystem;

public class IncomeManager : IdleStatObjectBase
{
    private float _incomeRate;

    public override void UpdateStat(string id)
    {
        _incomeRate = (float)IdleStat.CurrentValue;
    }
}
