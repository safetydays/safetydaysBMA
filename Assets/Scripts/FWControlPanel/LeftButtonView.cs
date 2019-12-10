using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButtonView : MonoBehaviour
{

    public FATController fatController;
    public Button btnAcousticSignal;
    public Button btnUeAb;

    private Color previousButtonColorAcousticSignal;
    private Color previousButtonColorUeAb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchOnAcousticSignalButtonAndLED()
    {
        Image img = btnAcousticSignal.GetComponent<Image>();
        img.color = Color.yellow;
        fatController.switchAcousticSignalLED();

    }
    public void switchOffAcoustigSignalButton()
    {
        Image img = btnAcousticSignal.GetComponent<Image>();
        img.color = Color.white;
    }

    public void switchOffUEAbButton()
    {
        Image img = btnUeAb.GetComponent<Image>();
        img.color = Color.white;
    }
    
    public void UEAbClicked()
    {
        Image img = btnUeAb.GetComponent<Image>();
        img.color = Color.yellow;
        fatController.switchOnUeAbLED();
    }


    public void testModeOn()
    {

        Image img = btnAcousticSignal.GetComponent<Image>();
        previousButtonColorAcousticSignal = img.color;
        img.color = Color.yellow;

        Image img2 = btnUeAb.GetComponent<Image>();
        previousButtonColorUeAb = img2.color;
        img2.color = Color.yellow;
    }

    public void testModeOff()
    {
        Image img = btnAcousticSignal.GetComponent<Image>();
        img.color = previousButtonColorAcousticSignal;

        Image img2 = btnUeAb.GetComponent<Image>();
        img2.color = previousButtonColorUeAb;
    }
}

    

