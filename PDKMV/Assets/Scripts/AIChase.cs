using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public float speed;
    private float distance;
    public float radius = 1f;
    AIHandler handler;
    PlayerStats stats;
    GameObject obj;
    BoxStats bs;
    PlayerStats ps;
    Animator animator;
    bool IsChasing = true;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Enemy_Player")
        {
            obj = GameObject.FindGameObjectWithTag("Player");
            distance = Vector2.Distance(transform.position, obj.transform.position);

            if (distance <= radius)
            {
                animator.SetBool("IsChasing", true);
                return;
            }
            Vector2 direction = obj.transform.position - transform.position;
            direction.Normalize();

            transform.position = Vector2.MoveTowards(this.transform.position, obj.transform.position, speed * Time.deltaTime);
        }

        else if (this.gameObject.tag == "Enemy_Music")
        {

            obj = GameObject.FindGameObjectWithTag("Boombox");
            distance = Vector2.Distance(transform.position, obj.transform.position);

            if (distance <= radius)
            {
                animator.SetBool("IsChasing", true);
                return;
            }
            Vector2 direction = obj.transform.position - transform.position;
            direction.Normalize();

            transform.position = Vector2.MoveTowards(this.transform.position, obj.transform.position, speed * Time.deltaTime);
        }



    }
}
