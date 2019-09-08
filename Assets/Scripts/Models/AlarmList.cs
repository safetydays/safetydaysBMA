using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Struct für die Melder-Nachricht, die vom Server (Lehrer) gesendet wurde
/// </summary>
[Serializable]
public struct Alarm
{
    // FalseAlarm: Fehlalarm, Alarm: Echter Alarm
    public enum AlarmType { FalseAlarm, Alarm, Fault, Off };
    public enum MelderType { Melder, Loeschanlage };

    public int id;
    public int deltatime;
    public string melderGruppeNummer;
    public MelderType melderTyp;
    public string infotext;
    public string meldertext;
    public AlarmType alarmTyp;

    /*public int Id;
    public string MelderGruppe;
    public string MelderNummer;
    public string MelderTyp;
    public string Melderart;
    public string Hinweistext;
    public string Freitext;
    public string TimeDelay;*/

    public Alarm(int pId, int pTime, MelderType pMelderTyp, string pMelderGruppeNummer, string pInfotext, string pMeldertext, AlarmType pAlarmTyp)
    {
        id = pId;
        deltatime = pTime;
        melderGruppeNummer = pMelderGruppeNummer;
        melderTyp = pMelderTyp;
        infotext = pInfotext;
        meldertext = pMeldertext;
        alarmTyp = pAlarmTyp;
    }
}

/// <summary>
/// Speichern der Melder-Nachrichten
/// </summary>
public class AlarmList : NetworkBehaviour
{
    public static AlarmList Instance;
    //public List<Alarm> internAlarmList;
    public class SyncAlarmList : SyncListStruct<Alarm> { }
    SyncAlarmList internAlarmList = new SyncAlarmList();

    //[SyncVar]
    //public bool isActive;

    void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance);
            Debug.Log("Alarm-List-Objekt schon vorhanden!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            this.gameObject.SetActive(true);
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //internAlarmList = new List<Alarm>();
        if (internAlarmList.Count == 0 && GameObject.FindGameObjectWithTag("GlobalSettings") != null 
            && GameObject.FindGameObjectWithTag("GlobalSettings").GetComponent<GlobalSettings>().clientType == GlobalSettings.ClientType.SinglePlayer
            && GlobalSettings.Instance.filePathJSON != null && GlobalSettings.Instance.filePathJSON.Length > 0)
        {
            SerializableScenarioList scenarioList;
            string json = File.ReadAllText(GlobalSettings.Instance.filePathJSON);
            scenarioList = JsonUtility.FromJson<SerializableScenarioList>(json);
            foreach (Alarm alarm in scenarioList.alarms)
            {
                Instance.addAlarm(alarm);
            }
        }
        else if (internAlarmList.Count == 0 && GameObject.FindGameObjectWithTag("GlobalSettings") != null && GameObject.FindGameObjectWithTag("GlobalSettings").GetComponent<GlobalSettings>().clientType == GlobalSettings.ClientType.SinglePlayer)
        {
            internAlarmList.Add(new Alarm(0, 0, Alarm.MelderType.Melder, "0203/04", "Gaststätte ZWD", "Test", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(1, 0, Alarm.MelderType.Melder, "0203/03", "Gaststätte ZWD", "Test2", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(2, 0, Alarm.MelderType.Melder, "0201/01", "Gaststätte U-E.12", "Test3", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(3, 0, Alarm.MelderType.Melder, "0203/02", "Gaststätte ZWD", "Test4", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(4, 0, Alarm.MelderType.Melder, "0203/01", "Gaststätte ZWD", "Test5", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(5, 0, Alarm.MelderType.Melder, "0202/01", "Gaststätte U-E.12", "Test6", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(6, 0, Alarm.MelderType.Melder, "0202/04", "Gaststätte U-E.12", "Test7", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(7, 0, Alarm.MelderType.Melder, "0202/03", "Gaststätte U-E.12", "Test8", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(8, 0, Alarm.MelderType.Melder, "0202/02", "Gaststätte U-E.12", "Test9", Alarm.AlarmType.Alarm));
        }
    }

    public int getAlarmCount()
    {
        return this.internAlarmList.Count;
    }

    public Alarm getAlarm(int number)
    {
        return this.internAlarmList[number];
    }

    public void addAlarm(Alarm alarm)
    {
        this.internAlarmList.Add(alarm);
    }

    public string toJSON()
    {
        SerializableScenarioList list = new SerializableScenarioList();
        foreach (Alarm alarm in internAlarmList)
            list.alarms.Add(alarm);
         return JsonUtility.ToJson(list, true);
    }
}
