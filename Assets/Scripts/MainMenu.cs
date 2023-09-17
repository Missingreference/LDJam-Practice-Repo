using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    Button startButton;
    Button rulesButton;
    TextMeshProUGUI gameTitleText;

    // Start is called before the first frame update
    void Start()
    {
        // find trasnform reference for start button
        Transform startButtonTransform = transform.Find("Start Button");

        startButton = startButtonTransform.GetComponent<Button>();

        //startButton = transform.Find("Start Button").GetComponent<Button>();


        // find transform reference to rules button

        Transform rulesButtonTransform = transform.Find("Rules Button");

        rulesButton = rulesButtonTransform.GetComponent<Button>();


        //find transform reference for title text

        Transform gameTitleTextTransform = transform.Find("Game Title");

        gameTitleText = gameTitleTextTransform.GetComponent<TextMeshProUGUI>();





        // messing with title appearance
            // wordspacing

        gameTitleText.wordSpacing = 10.1f;

            // colour
        
        Color32 myColour = new Color32(100, 100, 2, 255);

        gameTitleText.outlineColor = myColour;


        Image myImage;

        myImage = transform.Find("Start Button").GetComponent<Image>();
        myImage = startButtonTransform.GetComponent<Image>();
        myImage = startButton.GetComponent<Image>();

        int myNumber = 100;
        float myFloatNumber = 1.0f;

        gameTitleText.text = myNumber.ToString();

        //gameTitleText.text = Random.Range(-100, 100).ToString();
    }

    void Update()
    {

        //gameTitleText.text = Random.Range(-100, 100).ToString();
    }
}
