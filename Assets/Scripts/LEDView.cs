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


    // Start is called before the first frame update
    void Start()
    {
        turnOn();
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
}
