using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class Player1 : MonoBehaviour {

    public Transform tr;
    public Light l;
    public GameManager gm;
    public Animator animator;

    //Version2--------------------------------------------------------
    private float speed = 5.0f;
    //private List<Transform> bodyParts = new List<Transform>();

    private float currentRotation;
    private float rotationSensibility = 300.0f;

    // Use this for initialization
    void Start()
    {
        changeLight();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.Q) || Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("RotateRight", false);
            animator.SetBool("RotateLeft", true);
            currentRotation += rotationSensibility * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("RotateRight", true);
            animator.SetBool("RotateLeft", false);
            currentRotation -= rotationSensibility * Time.deltaTime;
        }
        else
        {
            animator.SetBool("RotateRight", false);
            animator.SetBool("RotateLeft", false);
        }

    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        MoveForward();
        Rotation();

    }

    void OnTriggerEnter2D(Collider2D wl)
    {
        changeLight();
    }

        void MoveForward()
    {
        //Transform tr = GetComponent<Transform>();
        tr.position += tr.up * speed * Time.deltaTime;
    }

    void Rotation()
    {
        //Transform tr = GetComponent<Transform>();
        tr.rotation = Quaternion.Euler(new Vector3(tr.rotation.x, tr.rotation.y, currentRotation));
    }

    void changeLight()
    {
        gm.getCurrentWindow();

        StartCoroutine(lightChange());
    }

    IEnumerator lightChange()
    {
        l.color = gm.getCurrentPlayer1Color();
        yield return null;
    }
}
