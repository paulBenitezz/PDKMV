using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    AIHandler ai;
    float health;
    Coroutine disableCoroutine; // Store a reference to the coroutine

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            Debug.Log("Barrier Collision");
            DestroyProjectile();
        }

        if (other.gameObject.tag == "Enemy_Player" || other.gameObject.tag == "Enemy_Music")
        {
            Debug.Log("Enemy Hit");
            ai = other.gameObject.GetComponent<AIHandler>();
            ai.GetAICurrentHealth();
            Debug.Log("AI Current Health = " + ai.AICurrentHealth);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        // Stop the coroutine if it's running
        if (disableCoroutine != null)
        {
            StopCoroutine(disableCoroutine);
        }

        // Destroy the projectile
        this.gameObject.SetActive(false);
    }

    // Called when the projectile is instantiated
    public void StartDisableCoroutine()
    {
        // Start the coroutine to disable the projectile after a delay
        disableCoroutine = StartCoroutine(DisableAfterTime());
    }

    IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(3); // Adjust this time as needed
        DestroyProjectile();
    }
}