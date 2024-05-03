using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float speed;

    public void move(Vector3 input)
    {
        transform.position += input * Time.deltaTime * speed;

    }

    
}
