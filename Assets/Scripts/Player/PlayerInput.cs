using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : PlayerComponent
{
    private InputControls inputControls;

    protected override void Awake()
    {
        base.Awake();

        inputControls = new InputControls();
    }

    private void OnEnable()
    {
        inputControls.Enable();
        inputControls.DefaultMap.Enable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
        inputControls.DefaultMap.Disable();
    }
}
