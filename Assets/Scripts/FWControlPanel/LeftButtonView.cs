using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButtonView : MonoBehaviour
{

    public FATController fatController;
    public Button btnAcousticSignal;
    public Button btnUeAb;
    
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



}

    

