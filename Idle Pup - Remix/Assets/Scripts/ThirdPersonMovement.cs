using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float normalSpeed;
    //private float backSpeed = 2f;
    private float turnSmoothVelocity;
    private float speedSmoothTime = 0.1f;
    private float gravity = 10f;
    private Animator animator;
    private AnimatorScript animScript;

    private CharacterController controller;

    private Transform camera;

    void Start()
    {

        controller = GetComponent<CharacterController>();

        camera = Camera.main.transform;
        animator = GetComponent<Animator>();
        animScript = GetComponent<AnimatorScript>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {

        setSpeed();

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            moveCharacter(direction.x, direction.z);
        }

        if (!animScript.isGrounded())
        {

            applyGravity();
        }
    }

    public CharacterController getController()
    {

        return controller;
    }

    private void setSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {

            normalSpeed = 10f;
        }
        else
        {

            normalSpeed = 4f;
        }
    }

    private void moveCharacter(float x, float z)
    {

        float targetAngle = Mathf.Atan2(x, z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, speedSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDirection.normalized * normalSpeed * Time.deltaTime);
    }

    private void applyGravity()
    {

        Vector3 gravityVector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }

        controller.Move(gravityVector * Time.deltaTime);
    }
}

