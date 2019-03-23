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

        imageError = panelLEDRunning.GetComponent<Image>();
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
    /// Betriebsbereit, dauerhaft grün leuchtend
    /// </summary>
    public void turnOn()
    {
        //always on
        Image img = panelLEDRunning.GetComponent<Image>();
        img.color = Color.green;
    }


    /// <summary>
    /// Errormodus on, yellow lighthing
    /// </summary>
    public void switchErrorOn()
    {
        imageError.color = Color.yellow;
    }

    public void switchErrorOff()
    {
        imageError.color = Color.yellow;
    }
    public void disableOffMode()
    {
        imageOff.color = Color.grey;
    }

    public void triggerErrorBlinking()
    {
        BlinkError();
    }
    public void stopErrorBlinking()
    {
        StopCoroutine("BlinkError");
        imageError.color = Color.yellow;   
    }
    public void triggerOffModeBlinking()
    {
        StopCoroutine("BlinkError");
        StartCoroutine("BlinkError");
       
    }
    public void stopOffModeBlinking()
    {
        StopCoroutine("BlinkError");
    }

    public void triggerAlarmBlinking()
    {
        imageAlarm.color = new Color(255, 0, 0, 1);
        StartAlarmBlinking();
    }
    public void stopAlarmBlinking()
    {
        StopCoroutine("BlinkAlarm");
        imageAlarm.color = Color.grey;
    }

    void StartAlarmBlinking()
    {
        StopCoroutine("BlinkAlarm");
        StartCoroutine("BlinkAlarm");
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
