using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : LevelComponent
{
    [SerializeField] private CinemachineVirtualCamera pauseCamera;
    [SerializeField] private float lerpSpeed;

    private bool isPaused;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        level.Settings.Events.OnEscapePressed += PauseGame;
    }

    private void OnDisable()
    {
        level.Settings.Events.OnEscapePressed -= PauseGame;
    }

    private void PauseGame()
    {
        isPaused = !isPaused;
        pauseCamera.Priority = isPaused ? 0 : -1;
    }
}
