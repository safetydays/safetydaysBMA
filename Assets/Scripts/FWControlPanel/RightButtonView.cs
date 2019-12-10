using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonView : MonoBehaviour
{
    public FATController fatController;
    public Button btnBMZReset;
    public Button btnBrandfallAb;

    private Color previousTestModeColor;
        
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    public void switchOnBrandFallLED()
    {
        Image img = btnBrandfallAb.GetComponent<Image>();
        if(img.color == Color.yellow)
            img.color = Color.white;
        else
            img.color = Color.yellow;

        fatController.switchonBrandFallLED();
        //LED and Button light
        //Set status that UE is abgeschaltet
    }

    public void switchOffBrandFallLED()
    {
        Image img = btnBrandfallAb.GetComponent<Image>();
        img.color = Color.white;
    }
    public void BMZResetClicked()
    {
        fatController.resetBMZ();

    }

    public void testModeOn()
    {
        
        Image img = btnBrandfallAb.GetComponent<Image>();
        previousTestModeColor = img.color;
        img.color = Color.yellow;
    }
   
    public void testModeOff()
    {
        Image img = btnBrandfallAb.GetComponent<Image>();
        img.color = previousTestModeColor;
    }
}
