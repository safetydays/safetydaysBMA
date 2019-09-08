using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FATController : MonoBehaviour
{
    public enum State { Alarmanzeige, Stoerung, Abschaltung, Historie, Test};
    public FATList fatList;
    public MessageView messageView;
    public LEDView ledView;
    public LeftLEDView fwControlPanelLeftLEDView;
    public RightLEDView fwControlPanelRightLEDView;
    public LeftButtonView fwControlPanelLeftButtonView;
    

    public ButtonMessageUpDown buttonMessageUp;
    public ButtonMessageUpDown buttonMessageDown;


    public ButtonMultipleSoundsView hausalarmSound;
    public ButtonMultipleSoundsView buzzerSound;

    public string stoerungMessage0 = "** Keine Störung **";
    public string stoerungMessage1 = "* Störungsmeldung *";

    public string abschaltungMessage = "** Abschaltung **";
    public string bereitMessage0Line1 = " * BMA App* ";
    public String bereitMessage0Line2 = "safety days 2019";
    public String bereitMessage1Line1 = "Universität Paderborn";

    public float timeForLightingUpAllLights = 5.0f;
    private float lightningTimer;
    private bool testLightMode;

    private int cursorPosition;

    // States und Flags
    private State fatState;
    private bool faultFlag;     // Flag für die Störungs-Anzeige

    private bool offFlag;       // Flag für die Abschalten-Anzeige
    private bool acousticsFlag = false; // Flag für das Abspielen von Sounds
    
    private static float ResetTimeInSeconds = 17;
    private float lastInputTime;
    private int lastBuzzerMessage;



    // Start is called before the first frame update
    void Start()
    {
        messageView.updateText1(bereitMessage0Line1,bereitMessage0Line2);
        messageView.updateText2(bereitMessage1Line1, "");
        cursorPosition = 0;
        fatState = State.Alarmanzeige;

        // Server neustarten im Einzelplayer
        if (GameObject.FindGameObjectWithTag("GlobalSettings") != null && GameObject.FindGameObjectWithTag("GlobalSettings").GetComponent<GlobalSettings>().clientType == GlobalSettings.ClientType.SinglePlayer)
        {
            GameObject.FindGameObjectWithTag("NetworkController").GetComponent<BMANetworkController>().restartHost();
        }
    }

    /// <summary>
    /// Nach der ResetTime ohne Input die Anzeige resetten 
    /// </summary>
    void Update()
    {
        if(fatState != State.Test && Time.time - lastInputTime > ResetTimeInSeconds)
        {
            cursorPosition = 0;
            fatState = State.Alarmanzeige;
            updateDisplay();
        }
      
        if (acousticsFlag)
        {
            hausalarmSound.PlaySecondClick();
            if (lastBuzzerMessage < fatList.getAlarmCount() - 1)
            {
                buzzerSound.PlaySecondClick();
            }
            else
            {
                buzzerSound.StopSecondClick();
            }
        }
        else
        {
            hausalarmSound.StopSecondClick();
        }

        if (testLightMode)
        {
            lightningTimer += Time.deltaTime;
        }
    }


    /// <summary>
    /// Display-Nachrichten anzeigen, je nach State
    /// Flags setzen bei bestimmten AlarmTypes
    /// </summary>
    public void updateDisplay()
    {
        if (fatList.getAlarmCount() > 0)
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

            //Löschanlage ausgelöst? -> Lampe anmachen
            if (fatList.getAlarm(fatList.getAlarmCount() - 1).melderTyp == Alarm.MelderType.Loeschanlage)
            {
                fwControlPanelLeftLEDView.switchLEDExtinguishOn();
            }
        }


        // Anzeige aktualisieren je nach State
        switch (fatState)
        {
            case State.Alarmanzeige:
                Debug.Log("Meldung zur Anzeige übergeben");
                if (fatList.getAlarmCount() > 0)
                {
                    Debug.Log("Alarm");
                    if (!fwControlPanelLeftLEDView.acousticSignalLEDIsOn())
                    {
                        acousticsFlag = true;
                    }
                    else
                    {
                        acousticsFlag = false;
                    }

                    // Aktuelles Element an der Cursorposition (obere Anzeige)
                    //messageView.updateText1(fatList.getAlarm(cursorPosition).melderGruppeNummer, fatList.getAlarm(cursorPosition).meldertext);
                    messageView.updateText1(fatList.getAlarm(cursorPosition).melderGruppeNummer + " " + fatList.getAlarm(cursorPosition).infotext, fatList.getAlarm(cursorPosition).meldertext);
                    //if(fatList.getAlarmCount() > cursorPosition+1)

                    // Letztes Element
                    //messageView.updateText2(fatList.getAlarm(fatList.getAlarmCount() - 1).melderGruppeNummer, fatList.getAlarm(fatList.getAlarmCount() - 1).meldertext);
                    messageView.updateText2(fatList.getAlarm(fatList.getAlarmCount() - 1).melderGruppeNummer + " " + fatList.getAlarm(fatList.getAlarmCount() - 1).infotext, fatList.getAlarm(fatList.getAlarmCount() - 1).meldertext);
                }
                else
                {
                    messageView.updateText1(bereitMessage0Line1, bereitMessage0Line2);
                    messageView.updateText2(bereitMessage1Line1, "");
                }
                break;
            case State.Stoerung:
                if (faultFlag)
                {
                    messageView.updateText1("", stoerungMessage1);
                    ledView.stopErrorBlinking();
                }
                else
                {
                    messageView.updateText1("", stoerungMessage0);
                }
                   
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

            case State.Test:
                messageView.updateText1("-----Test-----", "");
                messageView.updateText2("BMA TEST Modus", "");
                break;

            default:
                messageView.updateText1(bereitMessage0Line1, bereitMessage0Line2);
                messageView.updateText2(bereitMessage1Line1, "");
                break;
        }

        // Weitere LEDs setzen
        if (fatList.getAlarmCount() > 0)
        {
            ledView.stopAlarmBlinking();
            fwControlPanelRightLEDView.switchImageBMZResetOn();

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
        fwControlPanelRightLEDView.switchImageBMZResetOn();

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
            default:
                fatState = State.Alarmanzeige;
                break;
        }
        this.updateDisplay();
        lastInputTime = Time.time;
    }

    public void switchOnAcousticSignalLED()
    {
        if(fwControlPanelLeftLEDView.acousticSignalLEDIsOn())
        {
            fwControlPanelLeftLEDView.switchLEDAcoustigSignalOff();
            fwControlPanelLeftButtonView.switchOffAcoustigSignalButton();
           
        }
        else
        {
            fwControlPanelLeftLEDView.switchLEDAcoustigSignalOn();
        }

    }
    public void switchOnUECheckSignalLED()
    {
        fwControlPanelRightLEDView.switchLEDUEExecutedOn();
    }

    public void switchOffUeCheckSignalLED()
    {
        fwControlPanelRightLEDView.switchLEDUEExecutedOff();
    }

    public void switchOnUeAbLED()
    {
        if(fwControlPanelLeftLEDView.ueAbLEDIsOn())
        {
            fwControlPanelLeftLEDView.switchLEDUEAbOff();
            fwControlPanelLeftButtonView.switchOffUEAbButton();
        }
        else
        {
            fwControlPanelLeftLEDView.switchLEDUEAbOn();
          
        }
    }
    public void switchonBrandFallLED()
    {
        if (fwControlPanelRightLEDView.brandfallLEDOn())
        {
            fwControlPanelRightLEDView.switchLEDBrandFallControlAbOff();
            fwControlPanelLeftButtonView.switchOffUEAbButton();
        }
        else {
            fwControlPanelRightLEDView.switchLEDBrandFallControlAbOn();
        }
    }

    public void shutDownBuzzer()
    {
        lastBuzzerMessage = fatList.getAlarmCount()-1;
    }
    public void resetBMZ()
    {
        ledView.disableAlarmLED();
        fwControlPanelLeftLEDView.switchLEDExtinguishOff();
        fwControlPanelRightLEDView.switchBMZResetOff();
        fatList.removeAllFalseAlarmsFromList();
        acousticsFlag = false; //ton ausmachen, kann aber wieder angehen
        messageView.updateText1(bereitMessage0Line1, bereitMessage0Line2);
        messageView.updateText2(bereitMessage1Line1, "");
    }

    public void activateTestMode()
    { 
        testLightMode = true;
        fatState = State.Test;
        ledView.stopAlarmBlinking();
        ledView.stopErrorBlinking();
        ledView.stopOffModeBlinking();

        acousticsFlag = true; 
    
        StartCoroutine(waitForTestModeFinishing());

    }

    IEnumerator waitForTestModeFinishing()
    {
        Debug.Log("Waiting for 5 seconds until test mode shutdown ");
        yield return new WaitUntil(() => lightningTimer >= timeForLightingUpAllLights);
        Debug.Log("Wait time is over, returning to mormal");

        lightningTimer = 0;
        testLightMode = false;
        ledView.disableAlarmLED();
        ledView.disableErrorLED();
        ledView.disableOffModeLED();
        fatState = State.Alarmanzeige;
    }
}
