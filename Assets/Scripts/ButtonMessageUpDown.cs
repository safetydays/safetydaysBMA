using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMessageUpDown : MonoBehaviour
{
    public FATController fatController;
    private bool ledOn;
    private bool testON;

    // Start is called before the first frame update
    void Start()
    {
        Image img = this.GetComponent<Image>();
        img.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if(testON)
        {
            Image img = this.GetComponent<Image>();
            img.color = Color.yellow;
        }
    }

    public void switchTestOn()
    {
        testON = true;
    }

    public void switchTestOff()
    {
        testON = false;
        Image img = this.GetComponent<Image>();
        img.color = Color.white;
    }

    public void displayNextMessageInHistory()
    {
        fatController.displayNextMessageInHistory();
    }

    public void displayPreviousMessageInHistory()
    {
        fatController.displayPreviousMessageInHistory();
    }

    public void turnOn()
    {
        //always on
        if (!ledOn)
        {
            Image img = this.GetComponent<Image>();
            img.color = Color.yellow;
            StartCoroutine("BlinkAlarm");
            ledOn = true;
        }
    }

    public void turnOff()
    {
        StopCoroutine("BlinkAlarm");
        Image img = this.GetComponent<Image>();
        img.color = Color.white;
        ledOn = false;
    }

    IEnumerator BlinkAlarm()
    {
        Image img = this.GetComponent<Image>();
        while (true)
        {
            if (img.color == Color.white)
            {
                img.color = Color.yellow;
                //Play sound
                yield return new WaitForSeconds(0.5f);
            }
            else
            { 
                img.color = Color.white;
                //Play sound
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}