using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelInput : LevelComponent
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

        inputControls.DefaultMap.Escape.performed += Escape_performed;
        inputControls.DefaultMap.Escape.canceled += Escape_canceled;
    }

    private void OnDisable()
    {
        inputControls.Disable();
        inputControls.DefaultMap.Disable();

        inputControls.DefaultMap.Escape.performed -= Escape_performed;
        inputControls.DefaultMap.Escape.canceled -= Escape_canceled;
    }

    private void Escape_performed(InputAction.CallbackContext obj) { level.Settings.Events.OnEscapePressed?.Invoke(); }
    private void Escape_canceled(InputAction.CallbackContext obj) => level.Settings.Events.OnEscapeReleased?.Invoke();
}
