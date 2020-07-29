using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour {

    public Transform trGeneral;
    public Transform tr1;
    public GameManager gm;
    private int i;
    private int lastScore = 0;
    private float speeGrowthX = 0.05F;
    private float speeGrowthY = 0.05F;

    // Use this for initialization
    void Start () {
		
        //tr.localScale = new Vector3(0.1F, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        if (lastScore != gm.getScore())
        {
            growth();
            lastScore = gm.getScore();

            Debug.Log("Score :" + gm.getScore());
            //shrink();
        }


    }

    void growth()
    {
        if (i < 100)
        {
            StartCoroutine(startProgression());
            i++;
        }
    }

    //void shrink()
    //{
    //    if (i >= 100)
    //    {
    //        StartCoroutine(endProgression());
    //        i--;
    //    }
    //}

    IEnumerator startProgression()
    {

            yield return new WaitForSeconds(1.0f);
            tr1.localScale += new Vector3(speeGrowthX, speeGrowthY, 0);


    }

    IEnumerator endProgression()
    {

            yield return new WaitForSeconds(1.0f);
            tr1.localScale -= new Vector3(speeGrowthX, speeGrowthY, 0);

    }

}
