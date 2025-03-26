 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : KitchenObjectHolder
{
    public static Player Instance { get; private set; }
    [SerializeField] private float movespeed = 7;
    [SerializeField] private float rotateSpeed = 10;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking = false;
    // Start is called before the first frame update
    private BaseCounter selectedCounter;
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }
    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        HandleInteraction();
    }


    private void FixedUpdate()
    {
        HandleMovement();
    }

    public bool IsWalking
    {
        get
        {
            return isWalking;
        }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        // HandleInteraction();
        selectedCounter?.Interact(this);
    }
    private void HandleMovement()
    {
        Vector3 directon = gameInput.GetMovementDirectionNormalized();

        isWalking = directon != Vector3.zero;

        transform.position += directon * Time.deltaTime * movespeed;
        if (directon != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, directon, Time.deltaTime * rotateSpeed);

        }
    }
     
    private void HandleInteraction()
    {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f,counterLayerMask))
        { 
            if(hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {
                //counter.Interact();
                SetSlectedCounter(counter);
            }
            else
            {
                SetSlectedCounter(null);
            }
        }
        else
        {
            SetSlectedCounter(null);
        }
    }
    public void SetSlectedCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();
            counter?.SelectCounter();
        }
        this.selectedCounter = counter;
    }
}
