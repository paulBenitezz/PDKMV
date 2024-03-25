using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHandler : MonoBehaviour
{
   public float AIMaxHealth = 2f;
   public float AICurrentHealth;
   
   void Awake() {
    AICurrentHealth = AIMaxHealth; 
   } 
    public void GetAICurrentHealth() {
        
        AICurrentHealth = AIDamageTake(AICurrentHealth);

    }

    public float AIDamageTake(float health)
    {
        health -= 1f;

        if (health <= 0)
        {
            AIHandleDeath();
        }
        return health;

    }

    public void AIHandleDeath()
    {
        Destroy(this.gameObject);
    }

}
