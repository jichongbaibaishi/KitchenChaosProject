using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput instance {  get; private set; }
    public event EventHandler OnInteractAction;
    public event EventHandler OnOperateAction;
    public event EventHandler OnPauseAction;
    private GameControls gameControl;
    private void Awake()
    {
        instance = this;
        gameControl = new GameControls();
        gameControl.Player.Enable();
        gameControl.Player.Interact.performed += Interact_performed;
        gameControl.Player.Operate.performed += Operate_performed;
        gameControl.Player.Pause.performed += Pause_performed;
    }
    private void onDestroy()
    {
        gameControl.Player.Interact.performed -= Interact_performed;
        gameControl.Player.Operate.performed -= Operate_performed;
        gameControl.Player.Pause.performed -= Pause_performed;
        gameControl.Dispose();
    }
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Operate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
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
