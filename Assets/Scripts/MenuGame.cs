using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{

    public GameObject Menu;
    public GameObject textStartPlay;
    public Color c;

    // Use this for initialization
    void Start()
    {

        if (Menu == null)
        {
            Menu = GameObject.Find("Menu_Jeu");
        }

        //RenderSettings.ambientLight = c;       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetButton("Fire1"))
        {
            StartCoroutine(startGame());
        }
    }

    IEnumerator startGame()
    {

        Menu.SetActive(false);
        textStartPlay.SetActive(false);

        SceneManager.LoadScene("Tutoriel");

        yield return null;
    }

}
