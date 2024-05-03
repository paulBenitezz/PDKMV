using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] MovementController movement;
    ProjectileLauncher pl;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<ProjectileLauncher>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            input.y += 1;
            
        }

        else if (Input.GetKey(KeyCode.A))
        {
            input.x += -1;
            
        }

        else if (Input.GetKey(KeyCode.S))
        {
            input.y += -1;
            
        }

        else if(Input.GetKey(KeyCode.D))
        {
            input.x += 1;
          
        }

        else 
        {
            
            //Debug.Log("Pause walking animation");
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shoot weapon");
            pl.shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }


        movement.move(input);

    }


}
