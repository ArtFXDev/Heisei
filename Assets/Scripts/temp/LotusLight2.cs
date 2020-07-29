using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotusLight2 : LightStart
{

    private float waitingTime = 0.01f; //20 times a second
    private float normalRange = 8.0f; //normal range of light
    private float flRange = 0.5f; //flickering range
    private YieldInstruction yield;
    public GameObject GOLight2;
    public Light lightc;
    public int windowNumber;
    public GameManager gm;

    //Param Light
    //Color c = Color.red;
    //float intensity = 30;

    // Use this for initialization
    void Start()
    {

        //GOLight2 = GameObject.Find("Point_Light2");

        //windowNumber = 2;

        //lightc = light1.AddComponent<Light>();
        //StartCoroutine(waiter());
        

        if (windowNumber == gm.getCurrentWindow())
        {
            //Debug.Log("Light is ON OR NOT");
            StartCoroutine(startLightSlow());
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (windowNumber == gm.getCurrentWindow() && lightc.enabled == false)
        {
            StartCoroutine(startLightSlow());
            //Debug.Log("Light is ON OR NOT");
        }
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D wl)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Player", if it is...

        if (wl.gameObject.CompareTag("Player1"))
        {
            gm.ValidateByPlayer1();
            collide();
        }

        if (wl.gameObject.CompareTag("Player2"))
        {
            gm.ValidateByPlayer1();
            collide();
        }
    }

    bool collide()
    {
        bool b = false;
        if(windowNumber == gm.getCurrentWindow())
        {
            b = true;
        }

        Debug.Log("Current Position :" + gm.getCurrentWindow() + "Windows Position :" + windowNumber + "Egale ===  " + b);

        //if (gm.getCurrentPosition() != 2)
        //{
        //    gm.setWindow(2);
        //    Debug.Log("Windows Position :" + windowNumber);
        //}
        //else
        //{
        //    gm.setWindow(4);
        //    Debug.Log("Windows Position :" + windowNumber);
        //}

        if (windowNumber == gm.getCurrentWindow() && gm.isValidateByBothFish())
        {
            //lightc.color = gm.getCurrentWindowColor();
            //lightc.intensity = gm.getLightIntensity();
            //lightc.enabled = !lightc.enabled;
            lightc.enabled = false;
            gm.nextWindow();
            //Debug.Log("Light is ON OR NOT");
        }

        

        return true;
    }

    IEnumerator startLightSlow()
    {
        lightc.color = gm.getCurrentWindowColor();
        lightc.intensity = gm.getLightIntensity();
        lightc.range = flRange;
        lightc.enabled = true;

        while (normalRange > flRange)
        {
            yield return new WaitForSeconds(waitingTime);
            flRange += 0.1f;
            lightc.range = flRange;

        }

        //IEnumerator waiter()
        //{

        //    while (true)
        //    {

        //        lightc.enabled = !(lightc.enabled);

        //        yield return new WaitForSeconds(waitingTime);

        //        lightc.color = Color.red;

        //        Debug.Log("Result Light : " + lightc);
        //        Debug.Log("Result Light boolean: " + lightc.enabled);

        //        yield return new WaitForSeconds(waitingTime);

        //        lightc.color = Color.green;
        //    }
        //}

        //if (startLight)
        //{
        //    lightc.range = flRange;
        //    lightc.color = Color.red;
        //    lightc.intensity = 10;
        //    lightc.enabled = true;
        //}
    }

}
