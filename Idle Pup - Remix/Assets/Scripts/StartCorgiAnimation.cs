using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCorgiAnimation : MonoBehaviour
{
    Animator animator;
    bool finalAnimationPlayed = false;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("pause") && Input.GetMouseButtonDown(0))
        {
            finalAnimationPlayed = true;
            animator.SetTrigger("onClick");
        }

        if (finalAnimationPlayed && !GetComponent<Renderer>().isVisible)
        {

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider plane)
    {
        if (plane.name == "Plane 1")
        {

            animator.SetTrigger("collidePlane1");

        } else if (plane.name == "Plane 2")
        {

            animator.SetTrigger("collidePlane2");
        }
    }


}
