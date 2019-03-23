using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftLEDView : MonoBehaviour
{
    public GameObject panelLEDRunning;
    public GameObject panelLEDExtinguishTriggered;
    public GameObject panelLEDAcoustigSignal;
    public GameObject panelLEEUe;

    private Image imageLEDRunning;
    private Image imageLEDExtinguish;
    private Image imageLEDAcoustigSignal;
    private Image imageLEDUEAb;



    // Start is called before the first frame update
    void Start()
    {
        imageLEDRunning = panelLEEUe.GetComponent<Image>();
        imageLEDExtinguish = panelLEDExtinguishTriggered.GetComponent<Image>();
        imageLEDAcoustigSignal = panelLEDAcoustigSignal.GetComponent<Image>();
        imageLEDUEAb = panelLEEUe.GetComponent<Image>();
        switchPanelLEDRunning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchPanelLEDRunning()
    {
        imageLEDRunning.color = Color.green;
    }

    public void switchLEDExtinguishOn()
    {
        imageLEDExtinguish.color = Color.red;
    }
    public void switchLEDExtinguishOff()
    {
        imageLEDExtinguish.color = Color.grey;
    }
    public void switchLEDAcoustigSignalOn()
    {
        imageLEDAcoustigSignal.color = Color.yellow;
    }
    public void switchLEDAcoustigSignalOff()
    {
        imageLEDAcoustigSignal.color = Color.grey;
    }
    public void switchLEDUEAbOn()
    {
        imageLEDUEAb.color = Color.yellow;
    }
    public void switchLEDUEAbOff()
    {
        imageLEDUEAb.color = Color.grey;
    }
}
