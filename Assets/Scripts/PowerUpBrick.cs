using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBrick : MonoBehaviour
{
    public Rigidbody2D Sword;

    private void OnDestroy()
    {
        Sword.gravityScale = 0.8f;
    }
}
