using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float speed = 5f;


    public void shoot(Vector3 targetPos) {
        
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward, targetPos - transform.position);
        newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up * speed;
        Destroy(newProjectile, 4);

    }
}
