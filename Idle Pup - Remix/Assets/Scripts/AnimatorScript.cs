using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{

    Animator animator;
    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        controlAnimations();
    }

    private void controlAnimations()
    {
        checkIdleSleepState();
        checkMovement();
        checkRunning();
        checkJump();
        checkSwimming();
    }

    private void checkIdleSleepState()
    {
        bool sleeping = animator.GetCurrentAnimatorStateInfo(0).IsName("Arm_Dog|Lie_Sleep");
        bool idle = animator.GetCurrentAnimatorStateInfo(0).IsName("Arm_Dog|idle_1");

        if (sleeping)
        {
            animator.SetBool("inSleep", true);
        }
        else
        {
            animator.SetBool("inSleep", false);
        }

        if (idle)
        {
            animator.SetBool("inIdle", true);
        }
        else
        {
            animator.SetBool("inIdle", false);
        }
    }

    private void checkMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void checkRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {

            animator.SetTrigger("JumpTrigger");
        }
    }

    public bool isGrounded()
    {
        RaycastHit hit;

        Vector3 playerOrigin = transform.position + cc.center;
        float radius = cc.radius;
        float distanceToGround = 0.05f;

        return Physics.SphereCast(playerOrigin, radius, Vector3.down, out hit, distanceToGround);
    }

    private void checkSwimming()
    {
        if (transform.position.y <= -0.6)
        {

            animator.SetBool("isSwimming", true);
        }
        else
        {
            animator.SetBool("isSwimming", false);
        }
    }
}
