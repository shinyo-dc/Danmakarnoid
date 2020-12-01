using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    Animator animator;
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootEnable();
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
    void ShootEnable()
    {
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("isShooting", true);
            if (animator.GetFloat("Speed") > 0.01f)
            {
                animator.SetBool("isShooting", false);
            }
        } 
    }
    void ShootDisable()
    {
        animator.SetBool("isShooting", false);
        Shoot();
    }
}
