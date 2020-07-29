using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static int score = 0;

    private static int randomColor = 0;
    private static int windowOrder = 9;
    private static int lastRandomColor = 0;
    private static int lastWindowsOrder = 9;    
    private float intensity = 40;
    private static bool player1Validate = false;
    private static bool player2Validate = false;

    private static Color colorOrange = new Color(255, 80, 0);
    private static Color colorLime = new Color(0, 255, 0);
    private static Color colorMagenta = new Color(255, 0, 255);

    private Color[] color1 = new Color[] { colorOrange, Color.yellow, Color.red };
    private Color[] color2 = new Color[] { colorLime, Color.cyan, Color.yellow };
    private Color[] color3 = new Color[] { colorMagenta, Color.red, Color.cyan };
    private List<Color[]> gameColors = null;

    void Awake()
    {

        gameColors = new List<Color[]>();
        gameColors.Add(color1);
        gameColors.Add(color2);
        gameColors.Add(color3);

        //colors[0] = new Color(253, 106, 2);
        //colors[1] = Color.green;
        //colors[2] = Color.magenta;
        //colors[3] = Color.cyan;
        //colors[4] = Color.red;
        //colors[5] = Color.yellow;
    }

    // Use this for initialization
    void Start()
    {
        //---------------------------------------Temp-------------------------------------
        //windowOrderColor[0] = colors[0]; windowOrder[0] = 9;
        //windowOrderColor[1] = colors[1]; windowOrder[1] = 1;
        //windowOrderColor[2] = colors[2]; windowOrder[2] = 5;
        //windowOrderColor[3] = colors[0]; windowOrder[3] = 7;
        //windowOrderColor[4] = colors[1]; windowOrder[4] = 9;
        //windowOrderColor[5] = colors[2]; windowOrder[5] = 2;
        //windowOrderColor[6] = colors[0]; windowOrder[6] = 6;
        //windowOrderColor[7] = colors[1]; windowOrder[7] = 3;
        //windowOrderColor[8] = colors[2]; windowOrder[8] = 7;
        //windowOrderColor[9] = colors[0]; windowOrder[9] = 8;
        //windowOrderColor[10] = colors[1]; windowOrder[10] = 1;
        //windowOrderColor[11] = colors[2]; windowOrder[11] = 3;
        //windowOrderColor[12] = colors[0]; windowOrder[12] = 7;
        //windowOrderColor[13] = colors[1]; windowOrder[13] = 4;
        //windowOrderColor[14] = colors[2]; windowOrder[14] = 1;
        //windowOrderColor[15] = colors[0]; windowOrder[15] = 5;
        //windowOrderColor[16] = colors[1]; windowOrder[16] = 2;
        //windowOrderColor[17] = colors[2]; windowOrder[17] = 8;
        //windowOrderColor[18] = colors[0]; windowOrder[18] = 3;
        //windowOrderColor[19] = colors[1]; windowOrder[19] = 5;
        //windowOrderColor[20] = colors[2]; windowOrder[20] = 2;
        //windowOrderColor[21] = colors[0]; windowOrder[21] = 8;
        //windowOrderColor[22] = colors[1]; windowOrder[22] = 5;
        //windowOrderColor[23] = colors[2]; windowOrder[23] = 2;
        //windowOrderColor[24] = colors[0]; windowOrder[24] = 9;
        //
        //for (int i = 0; i < 8; i++)
        //{
        //    player1[i] = colors[4];
        //    player2[i] = colors[5];
        //    player1[i+1] = colors[3];
        //    player2[i+1] = colors[5];
        //    player1[i+2] = colors[3];
        //    player2[i+2] = colors[4];
        //}

    }

    // Update is called once per frame
    void Update () {
		
	}

    public float getLightIntensity()
    {
        return intensity;
    }
    
    public void nextWindow()
    {
        player1Validate = false;
        player2Validate = false;
        windowOrder = Random.Range(1, 9);
        randomColor = Random.Range(0, 3);

        while(windowOrder == lastWindowsOrder )
        {
            windowOrder = Random.Range(1, 9);
        }

        while (randomColor == lastRandomColor)
        {
            randomColor = Random.Range(0, 3);
        }

        lastWindowsOrder = windowOrder;
        lastRandomColor = randomColor;

        score++;
    }

    public void ValidateByPlayer1()
    {
        //Debug.Log("Validate Player1!");
        player1Validate = true;
    }

    public void ValidateByPlayer2()
    {
        //Debug.Log("Validate Player2!");
        player2Validate = true;
    }

    public bool isValidateByBothFish()
    {
        bool b = false;

        if(player1Validate && player2Validate)
        {
            //Debug.Log("Validate by both!");
            b = true;
        }

        return b;
    }

    public int getCurrentWindow()
    {
        return windowOrder;
    }

    public Color getCurrentWindowColor()
    {
        Color[] c = gameColors[randomColor];
        return c[0];
    }

    public Color getCurrentPlayer1Color()
    {
        Color[] c = gameColors[randomColor];
        return c[1];
    }

    public Color getCurrentPlayer2Color()
    {
        Color[] c = gameColors[randomColor];
        return c[2];
    }

    public int getScore()
    {
        return score;
    }

    //public void setWindowIndex(int i)
    //{
    //    actualIndexWindowActivate = i;
    //}

    //public int[] getWindowOrder()
    //{
    //    return windowOrder;
    //}

    //public Color[] getWindowOrderColor()
    //{
    //    return windowOrderColor;
    //}
}
