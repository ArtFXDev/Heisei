using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotusLight : LightStart
{

    private float waitingTime = 0.01f; //20 times a second
    private float normalRange = 7.0f; //normal range of light
    private float flRange = 0.5f; //flickering range
    private YieldInstruction yield;
    public Light lightc;
    public int windowNumber;
    public GameManager gm;

    // Use this for initialization
    void Start()
    {
        if (windowNumber == gm.getCurrentWindow())
        {
            waitStart();
            StartCoroutine(startLightSlow());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (windowNumber == gm.getCurrentWindow() && lightc.enabled == false)
        {
            StartCoroutine(startLightSlow());
        }
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D wl)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Player", if it is...
        if (windowNumber == gm.getCurrentWindow() && wl.gameObject.CompareTag("Player1"))
        {
            //Debug.Log("is Collide By P1");
            gm.ValidateByPlayer1();
            collide();
        }

        if (windowNumber == gm.getCurrentWindow() && wl.gameObject.CompareTag("Player2"))
        {
            //Debug.Log("is Collide By P2");
            gm.ValidateByPlayer2();
            collide();
        }
    }

    bool collide()
    {
        bool b = false;
        if (windowNumber == gm.getCurrentWindow())
        {
            b = true;
        }

        if (windowNumber == gm.getCurrentWindow() && gm.isValidateByBothFish())
        {
            //Debug.Log("is Validate By Both");
            lightc.enabled = false;
            gm.nextWindow();
        }
        return b;
    }

    IEnumerator startLightSlow()
    {
        lightc.color = gm.getCurrentWindowColor();
        lightc.intensity = 0.25f;
        float f = flRange;
        lightc.range = f;
        lightc.enabled = true;

        while (normalRange > f)
        {
            yield return new WaitForSeconds(waitingTime);
            f += 0.05f;
            lightc.range = f;

        }
    }

    IEnumerable waitStart()
    {
        yield return new WaitForSeconds(1.0f);
    }

}
