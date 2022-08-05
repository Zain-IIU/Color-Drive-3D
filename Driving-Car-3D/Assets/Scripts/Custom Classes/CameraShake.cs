using System;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private CinemachineBasicMultiChannelPerlin shakePerlin;

    [SerializeField] private float timeToShake;
    private float timer;
    [SerializeField] private float amplitude;
    private void Start()
    {
        shakePerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        EventsManager.OnCarCollision += ShakeCamera;
    }

    private void OnDisable()
    {
        EventsManager.OnCarCollision -= ShakeCamera;
        shakePerlin.m_AmplitudeGain = 0;
    }

    private void Update()
    {
        if (!(timer > 0)) return;
        timer -= Time.deltaTime;
        if (!(timer <= 0)) return;
        timer = timeToShake;
        shakePerlin.m_AmplitudeGain = 0;

    }

    private void ShakeCamera()
    {
        shakePerlin.m_AmplitudeGain = amplitude;
        timer = timeToShake;
    }
}
