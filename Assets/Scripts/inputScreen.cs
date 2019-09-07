using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

public class inputScreen : MonoBehaviour
{
    List<string> melderart_list = new List<string> { "Brand", "Rauch", "CO" };
    List<string> timedelay_list = new List<string> { "0", "30", "60", "90" };

    public Dropdown m_Dropdown_Melderart;
    public Dropdown m_Dropdown_TimeDelay;

    public Toggle m_automatisch;
    public Toggle m_handmelder;
    public Toggle m_loeschanlage;
    public Toggle m_fehlalarm;

    public InputField m_meldergruppe;
    public InputField m_meldernummer;
    public InputField m_infotext;
    public InputField m_meldertext;

    public Text timedelayLbl;
    public Text infoText;
    public Text m_currentScenario;
    public Text m_maxScenario;

    public int alarmid;
    public int alarmid_max;

    public int firstRun = 0;

    public int currentID = 0;

    public AlarmList alarmList;

    public List<Alarm> localAlarmList = new List<Alarm>();


    // Start is called before the first frame update
    void Start()
    {
        firstRun = 0;

        initializeMelderart();
        initializeTimeDelay();

        m_infotext.text = "Brandalarm";

        localAlarmList.Clear();

        if (GlobalSettings.Instance.filePathJSON != "")
        {
            addAlarmsFromJSON(GlobalSettings.Instance.filePathJSON);
            currentID = 0;
            provideData(currentID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int l_currentID = currentID + 1;
        m_currentScenario.text = l_currentID.ToString();
        m_maxScenario.text = localAlarmList.Count.ToString();
    }

    void initializeMelderart()
    {
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
        Alarm.MelderType meldertyp = Alarm.MelderType.Melder;
        Alarm.AlarmType alarmtyp = Alarm.AlarmType.Alarm;

        //count up alarmid
        alarmid = ++alarmid_max;
        
        //extract meldertyp from checkboxes
        if (m_handmelder.isOn)
        {
            //for alarm reasons only "Melder" exists
            meldertyp = Alarm.MelderType.Melder;
        }
        if (m_loeschanlage.isOn)
        {
            meldertyp = Alarm.MelderType.Loeschanlage;
        }
        if (m_automatisch.isOn)
        {
            meldertyp = Alarm.MelderType.Melder;
        }

        //check if fehlalarm is active
        if (m_fehlalarm.isOn)
        {
            alarmtyp = Alarm.AlarmType.FalseAlarm;
        }

        //convert timedelay from string of dropdown to int
        int timedelay;
        int.TryParse(timedelayLbl.text, out timedelay);

        //concatenate group and number
        string l_melderinfo = m_meldergruppe.text + "/" + m_meldernummer.text;

        // hinweistext meldertype are not passed
        localAlarmList.Add(new Alarm(alarmid, timedelay, meldertyp, l_melderinfo, m_infotext.text, m_meldertext.text, alarmtyp));

    }

    public void addAlarmToLocalQueue()
    {
        infoText.text = "";
        //check if neccessary fields are filled
        if (m_meldernummer.text == "" || m_meldergruppe.text == "" || m_meldertext.text == "" || m_infotext.text == "")
        {
            infoText.text = "Bitte alle Pflichtfelder füllen";
        }
        else
        {
            // go!
            generateScenarioFromInput();
            currentID = localAlarmList.Count - 1;
            infoText.text = "Melder wurde in den lokalen Puffer gestellt.";
        }
    }

    public void manualAlarm()
    {
        if (localAlarmList.Count > 0)
        {
            alarmList.gameObject.SetActive(true);
            alarmList.addAlarm(localAlarmList[currentID]);
            infoText.text = "Meldung wurde der an die BMA gesendet.";
        }
        else
        {
            addAlarmToLocalQueue();
            manualAlarm();
            alarmid_max = alarmid;
        }
    }

   /* public void setOnlyOneToggleActive()
    {
        if (firstRun >= 2)
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
    */

    public void jumpScenario()
    {
        if (localAlarmList.Count > 1)
        {
            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "NextScenario_Btn":
                    if (localAlarmList.Count == currentID + 1)
                    {
                        currentID = 0;
                    }
                    else
                    {
                        currentID++;
                    }
                    break;
                case "PrevScenario_Btn":
                    if (currentID == 0)
                    {
                        currentID = localAlarmList.Count - 1;
                    }
                    else
                    {
                        currentID--;
                    }
                    break;
                default:
                    break;
            }

            provideData(currentID);
        }

    }

    public void provideData(int index)
    {
        string[] l_melderinfo = localAlarmList[currentID].melderGruppeNummer.Split('/');
        m_meldergruppe.text = l_melderinfo[0];
        m_meldernummer.text = l_melderinfo[1];
        m_infotext.text = localAlarmList[currentID].infotext;
        m_meldertext.text = localAlarmList[currentID].meldertext;

        if (localAlarmList[currentID].alarmTyp == Alarm.AlarmType.FalseAlarm)
        {
            m_fehlalarm.isOn = true;
        }
        else
        {
            m_fehlalarm.isOn = false;
        }

        if (localAlarmList[currentID].melderTyp == Alarm.MelderType.Loeschanlage)
        {
            m_loeschanlage.isOn = true;
        }

        if (localAlarmList[currentID].melderTyp == Alarm.MelderType.Melder)
        {
            m_automatisch.isOn = true;
        }

        m_Dropdown_TimeDelay.value = localAlarmList[currentID].deltatime;

        alarmid = localAlarmList[currentID].id;
    }

    public void callSample()
    {
        localAlarmList.Clear();
        localAlarmList.Add(new Alarm(0, 0, Alarm.MelderType.Melder, "0203/04", "Gaststätte ZWD", "Test", Alarm.AlarmType.Alarm));
        localAlarmList.Add(new Alarm(1, 0, Alarm.MelderType.Melder, "0203/03", "Gaststätte ZWD", "Test2", Alarm.AlarmType.Alarm));
        localAlarmList.Add(new Alarm(2, 0, Alarm.MelderType.Melder, "0201/01", "Gaststätte U-E.12", "Test3", Alarm.AlarmType.Alarm));
        localAlarmList.Add(new Alarm(3, 0, Alarm.MelderType.Melder, "0203/02", "Gaststätte ZWD", "Test4", Alarm.AlarmType.Alarm));
        localAlarmList.Add(new Alarm(4, 0, Alarm.MelderType.Melder, "0203/01", "Gaststätte ZWD", "Test5", Alarm.AlarmType.Alarm));
        localAlarmList.Add(new Alarm(5, 0, Alarm.MelderType.Melder, "0202/01", "Gaststätte U-E.12", "Test6", Alarm.AlarmType.Alarm));
        localAlarmList.Add(new Alarm(6, 0, Alarm.MelderType.Melder, "0202/04", "Gaststätte U-E.12", "Test7", Alarm.AlarmType.Alarm));
        localAlarmList.Add(new Alarm(7, 0, Alarm.MelderType.Melder, "0202/03", "Gaststätte U-E.12", "Test8", Alarm.AlarmType.Alarm));
        localAlarmList.Add(new Alarm(8, 0, Alarm.MelderType.Melder, "0202/02", "Gaststätte U-E.12", "Test9", Alarm.AlarmType.Alarm));
        currentID = 0;
        provideData(currentID);
        alarmid_max = 2;
    }

    public string toJSON()
    {
        SerializableScenarioList list = new SerializableScenarioList();
        foreach (Alarm alarm in localAlarmList)
            list.alarms.Add(alarm);
        return JsonUtility.ToJson(list, true);
    }

    public void addAlarmsFromJSON( string path)
    {
        SerializableScenarioList scenarioList;

        scenarioList = JsonUtility.FromJson<SerializableScenarioList>(path);
        foreach(Alarm alarm in scenarioList.alarms)
        {
            
            localAlarmList.Add(alarm);

        }
    }
}
