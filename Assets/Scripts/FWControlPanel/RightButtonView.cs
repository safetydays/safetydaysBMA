using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonView : MonoBehaviour
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

    public void switchOnUEExecutedLED()
    {
        fatController.switchOnUESignalLED();
    }
}
