using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUENrTrigger : MonoBehaviour
{

    public FATController fatController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void onPress()
    {
        fatController.switchOnUECheckSignalLED();
    }

    public void onRelease()
    {
        fatController.switchOffUeCheckSignalLED();
    }
}
