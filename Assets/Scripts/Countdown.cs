using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{

    public int timeLeft = 120;
    public Text countDownText;

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.1f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    // Use this for initialization
    void Start()
    {
        BeginFade(-1);
        countDownText.text = "";
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    // Only show time for the last 10s
    void FixedUpdate()
    {

        countDownText.text = "";
        //StartCoroutine("TextTimer");
        textTime();
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    void textTime()
    {

        if (timeLeft <= 10)
        {
            StartCoroutine("TextTimer");

            if (timeLeft <= 0)
            {

                countDownText.text = ("Time Up");
                //StopAllCoroutines();
                StartCoroutine("StartFadeTime");
            }
        }
    }

    IEnumerator TextTimer()
    {
        countDownText.text = (timeLeft.ToString());

        yield return null;
    }

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    //void OnlevelWasLoaded()
    //{
    //    BeginFade(-1);
    //}

    IEnumerator StartFadeTime()
    {
        float fadeTime = BeginFade(1);

        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene("Ending");
    }
}
