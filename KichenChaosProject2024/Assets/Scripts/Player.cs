 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 7;
    [SerializeField] private float rotateSpeed = 10;
    [SerializeField] private GameInput gameInput;

    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directon = gameInput.GetMovementDirectionNormalized();

        isWalking = directon != Vector3.zero;

        transform.position += directon * Time.deltaTime*movespeed;
        if(directon != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, directon, Time.deltaTime * rotateSpeed);
         
        }
       
    }
    public bool IsWalking
    {
        get
        {
            return isWalking;
        }
    }
}
