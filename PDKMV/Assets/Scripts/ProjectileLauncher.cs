using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] GameObject[] projectiles;

    [SerializeField] float ProjectileSpeed = 5f;
    [SerializeField] protected Transform Muzzle;
    private PlayerAim pa;

    public void shoot(Vector3 targetPos) {
        int randomIndex = Random.Range(0, projectiles.Length);
        GameObject selectedProjectile = projectiles[randomIndex];

        Vector2 shootDirection = (targetPos - Muzzle.position).normalized;
       

        GameObject newProjectile = Instantiate(selectedProjectile, Muzzle.position, Quaternion.identity);

        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        newProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        
        newProjectile.GetComponent<Rigidbody2D>().velocity = shootDirection * ProjectileSpeed;
        Destroy(newProjectile, 4);

    }
}
