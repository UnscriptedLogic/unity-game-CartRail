using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyCamera : MonoBehaviour
{
    private CinemachineVirtualCamera pauseCamera;
    private CinemachineTrackedDolly dolly;
    private bool awaitNotLive;

    public void OnCameraLive(ICinemachineCamera toCamera, ICinemachineCamera fromCamera)
    {
        pauseCamera = toCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        dolly = pauseCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        dolly.m_PathPosition = 1;
        awaitNotLive = true;
    }

    private void FixedUpdate()
    {
        if (!awaitNotLive) return;

        if (!CinemachineCore.Instance.IsLive(pauseCamera))
        {
            dolly.m_PathPosition = 0;
            awaitNotLive = false;
        }
    }
}
