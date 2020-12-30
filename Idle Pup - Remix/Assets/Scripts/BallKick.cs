using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKick : MonoBehaviour
{
    private float kickForce;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (collision.transform.GetComponent<ThirdPersonMovement>().normalSpeed == 9f)
            {

                kickForce = 6f;
            }
            else
            {

                kickForce = 4f;
            }

            Vector3 kickDirection = (collision.transform.position - transform.position).normalized;
            rb.AddForce(-kickDirection * kickForce, ForceMode.Impulse);
        }
    }
}
