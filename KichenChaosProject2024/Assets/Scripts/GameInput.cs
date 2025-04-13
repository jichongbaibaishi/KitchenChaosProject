using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput instance {  get; private set; }
    public event EventHandler OnInteractAction;
    public event EventHandler OnOperateAction;
    public event EventHandler OnPauseAction;
    private GameControls gameControl;

    public enum BindingType
    {
        Up,
        Down, 
        Left, 
        Right,
        Interact,
        Operate,
        Pause
    }
        
    private void Awake()
    {
        instance = this;
        gameControl = new GameControls();
        gameControl.Player.Enable();
        gameControl.Player.Interact.performed += Interact_performed;
        gameControl.Player.Operate.performed += Operate_performed;
        gameControl.Player.Pause.performed += Pause_performed;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("开始绑定");
            gameControl.Player.Disable();
            gameControl.Player.Move.PerformInteractiveRebinding(1).OnComplete(callback =>
            {
                print(callback.action.bindings[1].path);
                print(callback.action.bindings[1].overridePath);

                callback.Dispose();
                print("绑定完成");
                gameControl.Player.Enable();
            }).Start();
        }
    }

    public string GetBindingDisplayString(BindingType bindingType)
    {
        switch (bindingType)
        {
            case BindingType.Up:
                return gameControl.Player.Move.bindings[1].ToDisplayString();

            case BindingType.Down:
                return gameControl.Player.Move.bindings[2].ToDisplayString();

            case BindingType.Left:
                return gameControl.Player.Move.bindings[3].ToDisplayString();

            case BindingType.Right:
                return gameControl.Player.Move.bindings[4].ToDisplayString();

            case BindingType.Interact:
                return gameControl.Player.Interact.bindings[0].ToDisplayString();

            case BindingType.Operate:
                return gameControl.Player.Operate.bindings[0].ToDisplayString();

            case BindingType.Pause:
                return gameControl.Player.Pause.bindings[0].ToDisplayString();

            default:
                break;
        }
        return "";
    }

    /*private void Start()
    {
        print();
        print(gameControl.Player.Move.bindings[2].ToDisplayString());
        print(gameControl.Player.Move.bindings[3].ToDisplayString());
        print(gameControl.Player.Move.bindings[4].ToDisplayString());
        print();
    }*/
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
