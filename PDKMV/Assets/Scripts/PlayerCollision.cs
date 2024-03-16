using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {

        Rigidbody2D rd = GetComponent<Rigidbody2D>();
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("Collision");
            rd.velocity = Vector3.zero;
        }

    }


}
