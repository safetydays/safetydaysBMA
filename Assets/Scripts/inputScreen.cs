using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;


public class inputScreen : MonoBehaviour
{

    List<string> melderart_list = new List<string> { "Rauch", "Gas", "Wasser" };
    List<string> timedelay_list = new List<string> { "30", "60", "90" };

    public Dropdown m_Dropdown_Melderart;
    public Dropdown m_Dropdown_TimeDelay;

    public Toggle m_automatisch;
    public Toggle m_handmelder;
    public Toggle m_loeschanlage;
    public Toggle m_fehlalarm;

    public InputField m_meldergruppe;
    public InputField m_meldernummer;
    public InputField m_hinweistext;
    public InputField m_freitext;

    public int alarmid;

    public int firstRun = 0;

    // Start is called before the first frame update
    void Start()
    {
        firstRun = 0;

        initializeMelderart();
        initializeTimeDelay();

        m_handmelder.isOn = false;
        m_loeschanlage.isOn = false;
        m_automatisch.isOn = true;

        m_hinweistext.text = "Brandalarm";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initializeMelderart() {
        m_Dropdown_Melderart.ClearOptions();
        m_Dropdown_Melderart.AddOptions(melderart_list);
    }

    void initializeTimeDelay()
    {
        m_Dropdown_TimeDelay.ClearOptions();
        m_Dropdown_TimeDelay.AddOptions(timedelay_list);
    }

    void generateScenarioFromInput()
    {
        //count up alarmid
        alarmid++;
        //extract meldertyp from checkboxes
        if (m_handmelder.isOn == true)
        {

        }
        if (m_loeschanlage.isOn == true)
        {

        }
        if (m_automatisch.isOn == true)
        {

        }

        //check if fehlalarm is active
        if (m_fehlalarm.isOn == true)
        {

        }

        int timedelay = 0;
        timedelay = System.Convert.ToInt32(m_Dropdown_TimeDelay.value);
    }

    public void saveData()
    {
        //check if neccessary fields are filled
        if (m_meldernummer.text == "" || m_meldergruppe.text == "" || m_freitext.text == "" || m_hinweistext.text == "")
        {
            EditorUtility.DisplayDialog("Oh man!", "Felder füllen", "OKAY");
        }
        else
        {
            // go!
            //EditorUtility.DisplayDialog("Oh man!", m_Dropdown_Melderart., "OKAY");
            generateScenarioFromInput();
        }




    }

    public void setOnlyOneToggleActive() {
        if (firstRun > 0)
        {

            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "Automatisch_Tgl":
                    if (m_automatisch.isOn == false)
                    {
                        m_automatisch.isOn = true;
                    }
                    else
                    {
                        m_handmelder.isOn = false;
                        m_loeschanlage.isOn = false;
                    }
                    break;
                case "Loeschanlage_Tgl":
                    if (m_loeschanlage.isOn == false)
                    {
                        m_loeschanlage.isOn = true;
                    }
                    else
                    {
                        m_handmelder.isOn = false;
                        m_automatisch.isOn = false;
                    }
                    break;
                case "Handmelder_Tgl":
                    if (m_handmelder.isOn == false)
                    {
                        m_handmelder.isOn = true;
                    }
                    else
                    {
                        m_loeschanlage.isOn = false;
                        m_automatisch.isOn = false;
                    }
                    break;
                default:
                    break;
            }
        }

        firstRun++;
    }
}
