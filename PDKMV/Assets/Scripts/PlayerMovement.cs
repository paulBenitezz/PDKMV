using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] MovementController movement;
    ProjectileLauncher pl;
    bool isMoving = false;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<ProjectileLauncher>();
        animator = GetComponentInParent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            input.y += 1;
            isMoving = true;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            input.x += -1;
            isMoving = true;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            input.y += -1;
            isMoving = true;
        }

        else if(Input.GetKey(KeyCode.D))
        {
            input.x += 1;
            isMoving = true;
        }

        else 
        {
            isMoving = false;
            // Debug.Log("Pause walking animation");
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shoot weapon");
            pl.shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        
        if (isMoving) {
            animator.enabled = true;
            animator.SetBool("isMoving", true);
            movement.move(input);
        }

        if (!isMoving) {
            animator.enabled= false;
        }
    }

}
