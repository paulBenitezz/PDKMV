using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField] MovementController movement;
    ProjectileLauncher pl;
    bool isMoving = false;
    Animator animator;
    public bool canShoot = true;
    PlayerStats player;
    public RuntimeAnimatorController maleController;
    public RuntimeAnimatorController femaleController;
    SFX SFX;

    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<ProjectileLauncher>();
        animator = GetComponentInParent<Animator>();
        player = GetComponentInParent<PlayerStats>();

        if (PlayerPrefs.GetInt("Sprite") == 1) {
            animator.runtimeAnimatorController = maleController;
            Debug.Log("Male Animator selected ");
        }
        else if (PlayerPrefs.GetInt("Sprite") == 0) 
        {
            animator.runtimeAnimatorController = femaleController;
            Debug.Log("Female Animator selected ");
        }

        if (SFX == null) {
            Debug.LogWarningFormat("SFX is null");
        }
        GameObject sfx = GameObject.FindGameObjectWithTag("SFX");
        SFX = sfx.GetComponent<SFX>();
        
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
            // Debug.Log("Shoot weapon");
            pl.shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            
            SFX.WeaponShot();
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
