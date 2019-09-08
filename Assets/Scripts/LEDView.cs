using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEDView : MonoBehaviour
{
    public GameObject panelLEDRunning;
    public GameObject panelLEDAlarm;
    public GameObject panelLEDError;
    public GameObject panelLEDOff;
    private Image imageAlarm;
    private Image imageError;
    private Image imageOff;

    // Start is called before the first frame update
    void Start()
    {
        turnOn();
        imageAlarm = panelLEDAlarm.GetComponent<Image>();
        imageAlarm.color = Color.grey;

        imageError = panelLEDError.GetComponent<Image>();
        imageError.color = Color.grey;

        imageOff = panelLEDOff.GetComponent<Image>();
        imageOff.color = Color.grey;
        // triggerAlarmBlinking(); only for testing
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Running, always green color
    /// </summary>
    public void turnOn()
    {
        //always on
        Image img = panelLEDRunning.GetComponent<Image>();
        img.color = Color.green;
    }

    public void triggerErrorBlinking()
    {
        StopCoroutine("BlinkError");
        StartCoroutine("BlinkError");
    }
    /// <summary>
    /// stop blinking, set color to yellow
    /// </summary>
    public void stopErrorBlinking()
    {
        StopCoroutine("BlinkError");
        imageError.color = Color.yellow;
    }
    /// <summary>
    /// disable error LED, color to grey
    /// </summary>
    public void disableErrorLED()
    {
        StopCoroutine("BlinkError");
        imageError.color = Color.grey;
    }
    /// <summary>
    /// Abschaltmodus blinking starts,
    /// </summary>
    public void triggerOffModeBlinking()
    {
        imageOff.color = Color.yellow;
        StopCoroutine("BlinkOffMode");
        StartCoroutine("BlinkOffMode");
    }
    /// <summary>
    /// Stop Abschaltmodus blinking, color to yellow 
    /// </summary>
    public void stopOffModeBlinking()
    {
        StopCoroutine("BlinkOffMode");
        imageOff.color = Color.yellow;
    }
    /// <summary>
    /// Disable Abschaltmodus LED, color to grey
    /// </summary>
    public void disableOffModeLED()
    {
        StopCoroutine("BlinkOffMode");
        imageOff.color = Color.grey;
    }

    /// <summary>
    /// Set alarm color to red, start blinking
    /// </summary>
    public void triggerAlarmBlinking()
    {
        imageAlarm.color = Color.red;
        //StopCoroutine("BlinkAlarm");
        //StartCoroutine("BlinkAlarm");
    }
    /// <summary>
    /// Stop blinking, red light on
    /// </summary>
    public void stopAlarmBlinking()
    {
        StopCoroutine("BlinkAlarm");
        imageAlarm.color = Color.grey;
    }
    /// <summary>
    /// Disables the alarm LED,  color to grey
    /// </summary>
    public void disableAlarmLED()
    {
        StopCoroutine("BlinkAlarm");
        imageAlarm.color = Color.grey;
    }

    IEnumerator BlinkAlarm()
    {
        while (true)
        {
            switch (imageAlarm.color.a.ToString())
            {
                case "0":
                    imageAlarm.color = new Color(imageAlarm.color.r, imageAlarm.color.g, imageAlarm.color.b, 1);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    imageAlarm.color = new Color(imageAlarm.color.r, imageAlarm.color.g, imageAlarm.color.b, 0);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
    IEnumerator BlinkError()
    {
        while (true)
        {
            switch (imageError.color.a.ToString())
            {
                case "0":
                    imageAlarm.color = new Color(imageError.color.r, imageError.color.g, imageError.color.b, 1);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    imageAlarm.color = new Color(imageError.color.r, imageError.color.g, imageError.color.b, 0);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
    IEnumerator BlinkOffMode()
    {
        while (true)
        {
            switch (imageError.color.a.ToString())
            {
                case "0":
                    imageOff.color = new Color(imageOff.color.r, imageOff.color.g, imageOff.color.b, 1);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    imageAlarm.color = new Color(imageOff.color.r, imageOff.color.g, imageOff.color.b, 0);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
}
