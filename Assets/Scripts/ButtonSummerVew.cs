using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSummerVew : MonoBehaviour
{
    public FATController fatController;
    public float timeToHoldUntilTest = 5.0f;
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

        if (mouseDown && testTimer >= timeToHoldUntilTest && fatController.isTestLightMode() == false)
        {
            Debug.Log("Initiating test after five seconds");
            fatController.activateTestMode();
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

        if (fatController.isTestLightMode())
            StartCoroutine(fatController.waitForTestModeFinishing());
       
    }
}
