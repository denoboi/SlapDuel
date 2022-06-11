using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private Tween shakeTween;

    private void Awake()
    {
        Instance = this;
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    //private void Update()
    //{
    //    if(_shakeTimer > 0)
    //    {
    //        _shakeTimer -= Time.deltaTime;

    //        if (_shakeTimer <= 0f)
    //        {
    //            //timer bitti
    //            var _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    //            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

    //        }
    //    }

    //}

    public void ShakeCamera(float intensity, float time)
    {
        var _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTween = DOTween.To(() => _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain, x => _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = x, 0, time);

    }
}
