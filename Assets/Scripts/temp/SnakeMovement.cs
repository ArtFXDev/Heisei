using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    public float speed = 3.5f;
    public List<Transform> bodyParts = new List<Transform>();

    public float currentRotation;
    public float rotationSensibility = 300.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q))
        {
            currentRotation += rotationSensibility * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentRotation -= rotationSensibility * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        MoveForward();
        Rotation();
    }

    void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void Rotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
    }
}
