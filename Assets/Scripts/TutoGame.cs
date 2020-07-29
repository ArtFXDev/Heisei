﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoGame : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

	// Use this for initialization
	void Start () {
        StartCoroutine(startGame());
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator startGame()
    {
        yield return new WaitForSeconds(4);

        float fadeTime = BeginFade(1);

        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Main");
    }

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnlevelWasLoaded()
    {
        BeginFade(-1);
    }
}
