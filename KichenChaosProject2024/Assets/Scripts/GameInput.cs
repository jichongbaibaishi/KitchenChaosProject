using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
   public Vector3 GetMovementDirectionNormalized()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");
    Vector3 direction = new Vector3(horizontal, 0, vertical);
    direction=direction.normalized;//µ¥Î»»¯

        return direction;
    }
}
