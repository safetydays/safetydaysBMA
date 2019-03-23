using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{
    public Text message1;
    public Text message2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText1(string text)
    {
        message1.text = text;

    }

    public void updateText2(string text)
    {
        message2.text = text;
    }
}
