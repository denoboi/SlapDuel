using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyImageTween : MonoBehaviour
{
    private Tween _punchTween;

    private void OnEnable()
    {
        Events.OnMoneyEarned.AddListener(MoneyPunch);
    }

    private void OnDisable()
    {
        Events.OnMoneyEarned.RemoveListener(MoneyPunch);
    }

    void MoneyPunch()
    {
        if (_punchTween != null) //to prevent punchtween bug(it was too big on UI)
            _punchTween.Kill(true);
        _punchTween = transform.DOPunchScale(Vector3.one * 0.05f, 0.9f);
    }
}
