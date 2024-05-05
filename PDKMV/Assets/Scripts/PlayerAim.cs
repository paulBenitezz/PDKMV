using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerAim : MonoBehaviour
{
    Vector2 worldPos, direction;
     [SerializeField] public GameObject weapon;
    float angle;
    public Vector3 localScale;
    bool isFlippedLeft = false;
    bool isFlippedRight = true; // default value
    void Update()
    {
        SpriteRotation();
    }

    void SpriteRotation()
    {
        // got this from this video https://www.youtube.com/watch?v=zYN1LTMdFYg
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (worldPos - (Vector2)weapon.transform.position).normalized;
        weapon.transform.right = direction;

        // flip weapon
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        localScale = new Vector3(1f, 1f, 1f);

        if (angle > 90 || angle < -90) {
            localScale.y = -1f;
            if (!isFlippedRight)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                isFlippedRight = true;
                isFlippedLeft = false;
            }

        }
        else {
            localScale.y = 1f;
           
            if (!isFlippedLeft)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                isFlippedLeft = true;
                isFlippedRight = false;
            }
        }

        weapon.transform.localScale = localScale;

    }
}
