using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public enum State { Alarmanzeige, Stoerung, Abschaltung, Historie, Test };
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
    public string bereitMessage0Line1 = " * BMA App Tutorialmodus * ";
    public String bereitMessage0Line2 = "safety days 2019";
    public String bereitMessage1Line1 = "Tippe auf die BMA,";
    public String bereitMessage1Line2 = "um sie Dir erklären zu lassen!";

    public float timeForLightingUpAllLights = 5.0f;
    private float lightningTimer;
    private bool testLightMode;

    private int cursorPosition;

    // States und Flags
    private State fatState;
    private bool faultFlag;     // Flag für die Störungs-Anzeige

    private bool offFlag;       // Flag für die Abschalten-Anzeige
    private bool acousticsFlag = false; // Flag für das Abspielen von Sounds
    private bool buzzerFlag;

    private static float ResetTimeInSeconds = 17;
    private float lastInputTime;
    private int lastBuzzerMessage;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        messageView.updateText1(bereitMessage0Line1, bereitMessage0Line2);
        messageView.updateText2(bereitMessage1Line1, bereitMessage1Line2);
        cursorPosition = 0;
        fatState = State.Alarmanzeige;
    }


}