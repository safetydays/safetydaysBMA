using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FATController : MonoBehaviour
{
    public enum State { Alarmanzeige, Stoerung, Abschaltung, Historie};
    public FATList fatList;
    public MessageView messageView;
    public LEDView ledView;
    public ButtonMessageUpDown buttonMessageUp;
    public ButtonMessageUpDown buttonMessageDown;

    public string stoerungMessage0 = "** Keine Störung **";
    public string stoerungMessage1 = "* Störungsmeldung *";
    public string abschaltungMessage = "** Abschaltung **";


    private int cursorPosition;
    private State fatState;
    private bool faultFlag;     // Flag für die Störungs-Anzeige
    private bool offFlag;       // Flag für die Abschalten-Anzeige
    private static float ResetTimeInSeconds = 17;
    private float lastInputTime;



    // Start is called before the first frame update
    void Start()
    {
        messageView.updateText1("* BMA App *", "safety days 2019");
        messageView.updateText2("Universität Paderborn", "");
        cursorPosition = 0;
        fatState = State.Alarmanzeige;
    }

    /// <summary>
    /// Nach der ResetTime ohne Input die Anzeige resetten 
    /// </summary>
    void Update()
    {
        if(Time.time - lastInputTime > ResetTimeInSeconds)
        {
            cursorPosition = 0;
            fatState = State.Alarmanzeige;
            updateDisplay();
        }
    }

    /// <summary>
    /// Display-Nachrichten anzeigen, je nach State
    /// Flags setzen bei bestimmten AlarmTypes
    /// </summary>
    public void updateDisplay()
    {
        // States wechseln - Strörungsmeldung
        if (fatList.getAlarm(fatList.getAlarmCount() - 1).alarmTyp == Alarm.AlarmType.Fault)
        {
            faultFlag = true;
            ledView.triggerAlarmBlinking();
        }
        // States wechseln - Abschalten
        if (fatList.getAlarm(fatList.getAlarmCount() - 1).alarmTyp == Alarm.AlarmType.Off)
        {
            offFlag = true;
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
                break;
            case State.Stoerung:
                if (faultFlag)
                {
                    messageView.updateText1("", stoerungMessage1);
                    ledView.stopErrorBlinking();
                }
                else
                    messageView.updateText1("", stoerungMessage0);
                messageView.updateText2("", "");
                break;
            case State.Abschaltung:
                if(offFlag)
                {
                    ledView.stopOffModeBlinking();
                }
                messageView.updateText1("", abschaltungMessage);
                messageView.updateText2("", "");
                break;
            case State.Historie:
                messageView.updateText1("", "");
                messageView.updateText2("", "");
                break;
            default:
                break;
        }

        // Weitere LEDs setzen
        if (fatList.getAlarmCount() > 0)
        {
            ledView.triggerAlarmBlinking();
        }
        if (fatList.getAlarmCount() > cursorPosition + 2)
            buttonMessageDown.turnOn();
    }

    /// <summary>
    /// Internen State auf Alarmanzeige setzen
    /// </summary>
    public void switchToAlarmanzeige()
    {
        fatState = State.Alarmanzeige;
    }

    /// <summary>
    /// Die nächste Meldung anzeigen
    /// </summary>
    public void displayNextMessageInHistory()
    {
        // CursorPosition ändern und Anzeige updaten
        if (fatList.getAlarmCount() > cursorPosition + 2)
        {
            cursorPosition++;

            // Previous-LED aktivieren
            buttonMessageUp.turnOn();
        }
        updateDisplay();

        ledView.stopAlarmBlinking();

        // Next-LED-Anzeige aktualisieren
        if (fatList.getAlarmCount() > cursorPosition + 2)
            buttonMessageDown.turnOn();
        else
            buttonMessageDown.turnOff();

        lastInputTime = Time.time;
    }

    /// <summary>
    /// Die vorherige Meldung anzeigen
    /// </summary>
    public void displayPreviousMessageInHistory()
    {
        if (cursorPosition > 0)
        {
            cursorPosition--;

            // Next LED
            buttonMessageDown.turnOn();
        }
        updateDisplay();

        ledView.stopAlarmBlinking();

        if (cursorPosition > 0)
            buttonMessageUp.turnOn();
        else
            buttonMessageUp.turnOff();

        lastInputTime = Time.time;
    }

    public void displayNextMode()
    {
        switch (fatState)
        {
            case State.Alarmanzeige:
                fatState = State.Stoerung;
                break;
            case State.Stoerung:
                fatState = State.Abschaltung;
                break;
            case State.Abschaltung:
                fatState = State.Historie;
                break;
            case State.Historie:
                fatState = State.Alarmanzeige;
                break;
        }
        this.updateDisplay();
        lastInputTime = Time.time;
    }

}
