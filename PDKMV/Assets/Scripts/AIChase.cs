using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public float speed;
    private float distance;
    public float radius = 1f;
    public float stoppingDistance = 2f;
    bool canAttack = true;
    float AttackCooldown = 1f;
    AIHandler handler;
    PlayerStats stats;
    BoxStats boxStats;
    GameObject obj;
    BoxStats bs;
    PlayerStats ps;
    Animator animator;
    Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        handler = GetComponent<AIHandler>();
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        GameObject boxObject = GameObject.FindGameObjectWithTag("Boombox");

        if (playerObject != null )
        {
            stats = playerObject.GetComponent<PlayerStats>();
        }
        else
        {
            Debug.LogError("Player object not found!");
        }

        if (boxObject != null)
        {
            boxStats = boxObject.GetComponent<BoxStats>();
        }
        else
        {
            Debug.LogError("Boombox object not found!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        ChasePlayer();
        ChaseBoombox();
        
    }

    public void ChasePlayer() {
        if (this.gameObject.tag == "Enemy_Player")
        {
            obj = GameObject.FindGameObjectWithTag("Player");
            distance = Vector2.Distance(transform.position, obj.transform.position);

            if (distance <= radius)
            {
                if (canAttack) { 
                AttackPlayer();
                animator.enabled = false;
                }
                else {
                    animator.enabled = true;
                    animator.SetBool("isChasing", true);
                }
            }
            Vector2 direction = obj.transform.position - transform.position;
            direction.Normalize();

            Vector2 targetPosition = (Vector2)obj.transform.position - direction * radius;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        }
    }

    public void ChaseBoombox() {
        if (this.gameObject.tag == "Enemy_Music")
        {

            obj = GameObject.FindGameObjectWithTag("Boombox");
            distance = Vector2.Distance(transform.position, obj.transform.position);

            if (distance <= radius)
            {
                if (canAttack) { 

                AttackBoombox();
                Debug.Log("Not Moving, animation should stop");
                animator.enabled = false;
                }
                else
                {
                    animator.SetBool("isChasing", true); // Continue chasing animation
                    //Debug.Log("Still Moving");
                }
            }
            

            Vector2 direction = obj.transform.position - transform.position;
            direction.Normalize();
            Vector2 targetPosition = (Vector2)obj.transform.position - direction * radius;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
        }
    }



    IEnumerator AttackPlayerCoroutine()
    {
        // Set the attack flag to false to prevent further attacks during cooldown
        canAttack = false;

        if (handler != null && stats != null)
        {
            handler.AIDealDamageToPlayer(stats);
            
        }
        else
        {
            Debug.LogWarningFormat("handler or playerstats is null");
        }
        // Wait for the cooldown period before enabling attacks again
        yield return new WaitForSeconds(AttackCooldown);

        // Set the attack flag to true to enable further attacks after cooldown
        canAttack = true;
    }

    IEnumerator AttackBoomboxCoroutine()
    {
        // Set the attack flag to false to prevent further attacks during cooldown
        canAttack = false;

        if (handler != null && boxStats != null)
        {
            animator.SetBool("isChasing", false);
            Debug.Log("is chasing to false");
            handler.AIDealDamageToBoombox(boxStats);
            
        }
        else
        {
            Debug.LogWarningFormat("handler or boxstats is null");
        }
        // Wait for the cooldown period before enabling attacks again
        yield return new WaitForSeconds(AttackCooldown);

        // Set the attack flag to true to enable further attacks after cooldown
        canAttack = true;
    }

    public void AttackPlayer()
    {
        StartCoroutine(AttackPlayerCoroutine());
    }

    public void AttackBoombox()
    {
        StartCoroutine(AttackBoomboxCoroutine());
    }
}
