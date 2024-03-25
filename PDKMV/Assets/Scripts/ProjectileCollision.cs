using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    AIHandler ai;
    float health;
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Barrier")
        {
            Debug.Log("Barrier Collision");
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Enemy_Player" || other.gameObject.tag == "Enemy_Music") {
            Debug.Log("Enemy Hit");
            ai = other.gameObject.GetComponent<AIHandler>();
            ai.GetAICurrentHealth();
            Debug.Log("AI Current Health = " + ai.AICurrentHealth);
            Destroy(this.gameObject);
        }
    }

}
