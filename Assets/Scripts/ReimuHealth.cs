using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuHealth : MonoBehaviour
{
    public int health = 1;
    public bool isInvulnerable = false; // when enter dash mode or slash mode

    public void TakeDamage()
    {
        if (isInvulnerable)
            return;

        health -= 1;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
