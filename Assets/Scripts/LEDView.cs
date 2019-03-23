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
    public Image imageAlarm;

    // Start is called before the first frame update
    void Start()
    {
        turnOn();
        imageAlarm = panelLEDAlarm.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void turnOn()
    {
        Image img = panelLEDRunning.GetComponent<Image>();
        img.color = Color.green;
    }

    public void turnOff()
    {
        Image img = panelLEDRunning.GetComponent<Image>();
        img.color = Color.yellow;
    }
    public void turnErrorOn()
    {
        Image img = panelLEDRunning.GetComponent<Image>();
        img.color = Color.yellow;
    }

    public void triggerAlarmBlinking()
    {
        StartBlinking();
    }
    void StartBlinking()
    {
        StopAllCoroutines();
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopAllCoroutines();
    }
    IEnumerator Blink()
    {
        while (true)
        {
            switch (imageAlarm.color.a.ToString())
            {
                case "0":
                    imageAlarm.color = new Color(255,0,0,1);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    imageAlarm.color = new Color(255,0,0,0);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
}
