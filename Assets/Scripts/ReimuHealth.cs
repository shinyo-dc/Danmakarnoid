using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuHealth : MonoBehaviour
{
    public int health = 3;
    public bool isInvulnerable = false; // when enter dash mode or slash mode this is true
    bool hit = false;
    public bool die = false;
    [SerializeField] Animator animator;

    public void TakeDamage()
    {
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
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        this.GetComponent<ReimuMovement>().enabled = false;
    }
    void HitDisable()
    {
        hit = false;
        animator.SetBool("isHit", hit);
        this.GetComponent<ReimuMovement>().enabled = true;
    }

    void Die()
    {
        die = true;
        animator.SetBool("isDead", die);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        this.GetComponent<ReimuMovement>().enabled = false;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
