using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftLEDView : MonoBehaviour
{


    public FATController fatController;

    public GameObject panelLEDRunning;
    public GameObject panelLEDExtinguishTriggered;
    public GameObject panelLEDAcoustigSignal;
    public GameObject panelLEEUe;

    private Image imageLEDRunning;
    private Image imageLEDExtinguish;
    private Image imageLEDAcoustigSignal;
    private Image imageLEDUEAb;

    private Image ImageLEDAcoustigSignal;



    // Start is called before the first frame update
    void Start()
    {
        imageLEDRunning = panelLEDRunning.GetComponent<Image>();
        imageLEDExtinguish = panelLEDExtinguishTriggered.GetComponent<Image>();
        ImageLEDAcoustigSignal = panelLEDAcoustigSignal.GetComponent<Image>();
        imageLEDUEAb = panelLEEUe.GetComponent<Image>();
        switchPanelLEDRunning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool acousticSignalLEDIsOn()
    {
        return ImageLEDAcoustigSignal.color == Color.yellow;
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
        ImageLEDAcoustigSignal.color = Color.yellow;
    }
    public void switchLEDAcoustigSignalOff()
    {
        ImageLEDAcoustigSignal.color = Color.grey;
    }
    public void switchLEDUEAbOn()
    {
        imageLEDUEAb.color = Color.yellow;
    }
    public void switchLEDUEAbOff()
    {
        imageLEDUEAb.color = Color.grey;
    }

    public bool ueAbLEDIsOn()
    {
        return imageLEDUEAb.color == Color.yellow;
       
    }
}
