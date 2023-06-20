using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    protected LevelController level;

    protected virtual void Awake()
    {
        level = GetComponent<LevelController>();
    }
}
