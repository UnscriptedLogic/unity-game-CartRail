using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerComponent : MonoBehaviour
{
    protected PlayerController player;
    protected LevelController level;

    protected virtual void Awake()
    {
        player = GetComponent<PlayerController>();
        level = LevelController.instance;
    }
}
