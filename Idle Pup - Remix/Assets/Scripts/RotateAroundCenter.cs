using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCenter : MonoBehaviour
{
    Transform camera;
    Vector3 center;

    void Start()
    {

        camera = Camera.main.transform;
        center = GameObject.FindGameObjectWithTag("Start").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        camera.RotateAround(center, Vector3.up, 0.1f);
    }
}
