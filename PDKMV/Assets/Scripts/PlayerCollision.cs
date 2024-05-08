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

        if (collision.gameObject.CompareTag("Heart"))
        {
            Debug.Log("Pickup Heart");
        }

        if (collision.gameObject.CompareTag("Wrench"))
        {
            Debug.Log("Pickup Wrench");
        }



    }

    public void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Heart"))
        {
            Debug.Log("Pickup Heart");
        }

        if (other.gameObject.CompareTag("Wrench"))
        {
            Debug.Log("Pickup Wrench");
        }
    }


}
