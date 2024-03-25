using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject gob;
    public float speed;
    private float distance;
    public float radius = 1f;
    AIHandler handler;
    PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, gob.transform.position);

        if (distance <= radius) {
            //handler.AIDamageInflict(stats.PlayerHealth);    // attack script
            //Debug.Log(stats.PlayerHealth);
            return;
        }
        Vector2 direction = gob.transform.position - transform.position;
        direction.Normalize();

        transform.position = Vector2.MoveTowards(this.transform.position, gob.transform.position, speed * Time.deltaTime);
    }
}
