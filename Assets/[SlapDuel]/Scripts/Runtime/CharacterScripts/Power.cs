using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCB.IncrimantalIdleSystem;

public class Power : IdleStatObjectBase
{
    Health _health;

    public Health Health { get { return _health == null ? _health = GetComponent<Health>() : _health; } }
    public override void UpdateStat(string id)
    {
        Health.PlayerPower = (float)IdleStat.CurrentValue;
    }
}
