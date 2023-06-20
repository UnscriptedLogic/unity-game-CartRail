using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerEvents playerEvents;

    public PlayerEvents Events { get { return playerEvents; } set { playerEvents = value; } }
}
