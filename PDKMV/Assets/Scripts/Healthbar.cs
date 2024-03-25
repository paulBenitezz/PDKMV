using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider healthbar;

    public void setHealth(float health)
    {
        healthbar.value = health;
    }

    public void setMaxHealth(float health) {
        healthbar.maxValue = health;
        healthbar.value = health;
    }
}
