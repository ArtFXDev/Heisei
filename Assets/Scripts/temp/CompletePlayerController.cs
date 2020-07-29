using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour
{
    //Version2--------------------------------------------------------
    private float speed = 7.0f;
    //private List<Transform> bodyParts = new List<Transform>();

    private float currentRotation;
    private float rotationSensibility = 300.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetAxis("Horizontal") > 0)
        {
            currentRotation += rotationSensibility * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") < 0)
        {
            currentRotation -= rotationSensibility * Time.deltaTime;
        }

    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        MoveForward();
        Rotation();
    }

    void MoveForward()
    {
        Transform tr = GetComponent<Transform>();
        tr.position += transform.up * speed * Time.deltaTime;
    }

    void Rotation()
    {
        Transform tr = GetComponent<Transform>();
        tr.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
    }
}
