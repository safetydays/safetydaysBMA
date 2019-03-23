using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{
    public Text message1Line1;
    public Text message1Line2;
    public Text message2Line1;
    public Text message2Line2;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText1(string textLine1, string textLine2)
    {
        message1Line1.text = textLine1;
        message1Line2.text = textLine2;
    }

    public void updateText2(string textLine1, string textLine2)
    {
        message2Line1.text = textLine1;
        message2Line2.text = textLine2;
    }
}
