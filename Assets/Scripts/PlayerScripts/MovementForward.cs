using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForward : MonoBehaviour
{
    [SerializeField] private float _speedOfMove;

    private void Update()
    {
        transform.Translate(Vector3.forward  * _speedOfMove * Time.deltaTime);
    }
    
}
