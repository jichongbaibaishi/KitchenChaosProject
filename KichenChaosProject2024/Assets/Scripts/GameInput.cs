using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private GameControls gameControl;
    private void Awake()
    {
        gameControl = new GameControls();
        gameControl.Player.Enable();
    }
    public Vector3 GetMovementDirectionNormalized()
    {

        Vector2 inputVector2= gameControl.Player.Move.ReadValue<Vector2>();
        //float horizontal = Input.GetAxisRaw("Horizontal");
    //float vertical = Input.GetAxisRaw("Vertical");
    Vector3 direction = new Vector3(inputVector2.x, 0,inputVector2.y);
    direction=direction.normalized;//单位化

        return direction;
    }
}
