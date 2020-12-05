using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuMovement : MonoBehaviour
{
    public ReimuController controller;
    public Animator animator;

    public float runSpeed = 40f;
    public float dashSpeed = 160f;
    float horizontalMove = 0f;
    bool dash = false;
    bool slash = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DashEnable();
        SlashEnable();
        MovementSpeed();
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("isDashing", dash);
        animator.SetBool("isSlashing", slash);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime);
    }
    private void MovementSpeed()
    {
        if (dash)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * dashSpeed;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
    }
    private void DashEnable() // enable dash and wait for the animation to cancel for calling the dash disable
    {
        if (Input.GetKeyDown(KeyCode.Z) && animator.GetFloat("Speed") >= 0.01)
        {
            dash = true;
        }
    }

    private void DashDisable()
    {
        dash = false;
    }
    private void SlashEnable()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            slash = true;
        }
    }
    private void SlashDisable()
    {
        slash = false;
    }
}
