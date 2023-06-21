using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[DefaultExecutionOrder(-1)]
public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelSettingsSO levelSettings;

    public LevelSettingsSO Settings => levelSettings;

    public static LevelController instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
}
