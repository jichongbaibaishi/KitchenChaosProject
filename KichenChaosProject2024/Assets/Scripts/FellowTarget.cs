using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowTarget : MonoBehaviour
{
   
    void FixedUpdate()
    {
        transform.position = Player.Instance.transform.position;
    }
}
