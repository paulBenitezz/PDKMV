using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField] MovementController movement;
    ProjectileLauncher pl;
    bool isMoving = false;
    Animator animator;
    GameLoader gameLoader;
    bool isPaused = false;
    public bool canShoot = true;

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

        if (Input.GetKey(KeyCode.Escape)) {

            if (!isPaused) {
                gameLoader.Pause();
                isPaused = true;
            }
            else {
                gameLoader.Unpause();
                isPaused = false;
            }

            
        }

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

        else if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
            isMoving = true;
        }

        else 
        {
            isMoving = false;
            // Debug.Log("Pause walking animation");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
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
