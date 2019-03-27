using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSummerVew : MonoBehaviour
{
    public FATController fatController;
    public float timeToHoldUntilTest = 5.0f;
    public float timeForLightingUpAllLights = 5.0f;
    private float lightingTimer = 0f;
    private bool testLightMode;
    private float testTimer = 0f;
    private  bool mouseDown;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown)
        {
            testTimer += Time.deltaTime;
        }
        if (testLightMode)
        {
            lightingTimer += Time.deltaTime;
        }
    }

    public void shutDownBuzzer()
    {
        fatController.shutDownBuzzer();
    }
    public void onPress()
    {
        mouseDown = true;
        shutDownBuzzer();
        testTimer = 0;
    }

    public void onRelease()
    {
        mouseDown = false;
   
        if (testTimer >= timeToHoldUntilTest)
        {
            Debug.Log("Initiating test after five seconds");
          fatController.activateTestMode();
        }
       
    }
}
