using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuHealth : MonoBehaviour
{
    public int health = 3;
    public bool isInvulnerable = false; // when enter dash mode or slash mode this is true
    bool hit = false;
    bool die = false;
    [SerializeField] Animator animator;

    public void TakeDamage()
    {
        Debug.Log(animator.name);
        if (isInvulnerable)
            return;

        health -= 1;
        
        if (health <= 0)
        {
            Die();
        }
        else
        {
            Hit();
        }
    }
    
    void Hit()
    {
        hit = true;
        animator.SetBool("isHit", hit);
    }
    void HitDisable()
    {
        hit = false;
        animator.SetBool("isHit", hit);
    }

    void Die()
    {
        die = true;
        animator.SetBool("isDead", die);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
