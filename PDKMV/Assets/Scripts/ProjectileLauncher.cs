using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] GameObject[] projectiles;
    [SerializeField] int poolSize = 10; // Adjust the pool size as needed
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] protected Transform muzzle;

    private List<GameObject>[] projectilePools;
    private int[] poolIndexes;
    private PlayerAim pa;

    void Start()
    {
        InitializePools();
    }

    void InitializePools()
    {
        projectilePools = new List<GameObject>[projectiles.Length];
        poolIndexes = new int[projectiles.Length];

        for (int i = 0; i < projectiles.Length; i++)
        {
            projectilePools[i] = new List<GameObject>();

            for (int j = 0; j < poolSize; j++)
            {
                GameObject newProjectile = Instantiate(projectiles[i]);
                newProjectile.SetActive(false);
                projectilePools[i].Add(newProjectile);
            }
        }
    }

    public void shoot(Vector3 targetPos)
    {
        int randomIndex = Random.Range(0, projectiles.Length);
        GameObject selectedProjectile = GetNextAvailableProjectile(randomIndex);

        if (selectedProjectile != null)
        {
            Vector2 shootDirection = (targetPos - muzzle.position).normalized;

            selectedProjectile.transform.position = muzzle.position;

            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            selectedProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            selectedProjectile.SetActive(true);
            selectedProjectile.GetComponent<Rigidbody2D>().velocity = shootDirection.normalized * projectileSpeed;

            StartCoroutine(DisableAfterTime(selectedProjectile));
        }
    }

    GameObject GetNextAvailableProjectile(int index)
    {
        int currentIndex = poolIndexes[index];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = projectilePools[index][currentIndex];
            currentIndex = (currentIndex + 1) % poolSize;
            if (!projectile.activeInHierarchy && projectile != null) // Check if projectile is not null
            {
                poolIndexes[index] = currentIndex;
                return projectile;
            }
        }
        return null;
    }
    IEnumerator DisableAfterTime(GameObject projectile)
    {
        yield return new WaitForSeconds(3); // Adjust this time as needed
        if (projectile != null) // Check if projectile is not null
        {
            projectile.SetActive(false); // Deactivate instead of destroying
        }
        
    }
}
