using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonView : MonoBehaviour
{
    public FATController fatController;
    public Button btnBMZReset;
    public Button btnBrandfallAb;
        
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
   
}
