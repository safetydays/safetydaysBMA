using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FATController : MonoBehaviour
{
    public FATList fatList;
    public MessageView messageView;

    private int cursorPosition;

    // Start is called before the first frame update
    void Start()
    {
        cursorPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateDisplay()
    {
        Debug.Log("Meldung zur Anzeige übergeben");
        messageView.updateText1(fatList.getAlarm(cursorPosition).meldung1, fatList.getAlarm(cursorPosition).meldung2);
        if(fatList.getAlarmCount() > cursorPosition+1)
            messageView.updateText2(fatList.getAlarm(cursorPosition+1).meldung1, fatList.getAlarm(cursorPosition + 1).meldung2);
    }

    public void displayNextMessageInHistory()
    {
        if (fatList.getAlarmCount() > cursorPosition + 1)
            cursorPosition++;
        updateDisplay();
    }

    public void displayPreviousMessageInHistory()
    {
        if (cursorPosition > 0)
            cursorPosition--;
        updateDisplay();
    }

}
