using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FATController : MonoBehaviour
{
    public enum State { Alarmanzeige, Stoerung, Abschaltung, Historie};
    public FATList fatList;
    public MessageView messageView;

    public string stoerungMessage0 = "** Keine Störung **";
    public string stoerungMessage1 = "* Störungsmeldung *";
    public string abschaltungMessage = "** Abschaltung **";

    private int cursorPosition;
    private State fatState;

    // Start is called before the first frame update
    void Start()
    {
        cursorPosition = 0;
        fatState = State.Alarmanzeige;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateDisplay()
    {
        // States wechseln
        if (fatList.getAlarm(fatList.getAlarmCount() - 1).alarmTyp == Alarm.AlarmType.Fault)
        {
            fatState = State.Stoerung;
        }

        // Anzeige aktualisieren je nach State
        switch (fatState)
        {
            case State.Alarmanzeige:
                Debug.Log("Meldung zur Anzeige übergeben");
                // Aktuelles Element an der Cursorposition (obere Anzeige)
                messageView.updateText1(fatList.getAlarm(cursorPosition).meldung1, fatList.getAlarm(cursorPosition).meldung2);
                //if(fatList.getAlarmCount() > cursorPosition+1)

                // Letztes Element
                messageView.updateText2(fatList.getAlarm(fatList.getAlarmCount() - 1).meldung1, fatList.getAlarm(fatList.getAlarmCount() - 1).meldung2);
                return;
            case State.Stoerung:
                messageView.updateText1("", stoerungMessage0);
                messageView.updateText2("", "");
                return;
            case State.Abschaltung:
                messageView.updateText1("", abschaltungMessage);
                messageView.updateText2("", "");
                return;
        }
        
    }

    public void displayNextMessageInHistory()
    {
        // CursorPosition ändern und Anzeige updaten
        if (fatList.getAlarmCount() > cursorPosition + 2)
            cursorPosition++;
        updateDisplay();

        // Next-LED-Anzeige aktualisieren
        if (fatList.getAlarmCount() > cursorPosition + 2)
            ; // Aktivieren
        else
            ; // Deaktivieren

        // Previous-LED aktivieren
    }

    public void displayPreviousMessageInHistory()
    {
        if (cursorPosition > 0)
            cursorPosition--;
        updateDisplay();

        if (cursorPosition > 0)
            ; // aktivieren
        else
            ; // deaktivieren

        // Next-Led aktivieren
    }

}
