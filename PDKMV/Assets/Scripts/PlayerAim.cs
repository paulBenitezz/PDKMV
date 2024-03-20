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
    void Update()
    {
        WeaponRotation();
    }

    void WeaponRotation()
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
        }
        else {
            localScale.y = 1f;
        }

        weapon.transform.localScale = localScale;

    }
}
