using System;
using System.Collections;
using System.Collections.Generic;
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
        if (internAlarmList.Count == 0 && GameObject.FindGameObjectWithTag("GlobalSettings") != null && GameObject.FindGameObjectWithTag("GlobalSettings").GetComponent<GlobalSettings>().clientType == GlobalSettings.ClientType.SinglePlayer)
        {
            internAlarmList.Add(new Alarm(0, 0, Alarm.MelderType.Melder, "06/3", "Melder Flur O", "", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(0, 0, Alarm.MelderType.Loeschanlage, "06/2", "Löschanlagen Test", "", Alarm.AlarmType.FalseAlarm));

            internAlarmList.Add(new Alarm(0, 0, Alarm.MelderType.Melder, "06/2", "Melder Flur W", "", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(0, 10, Alarm.MelderType.Melder, "06/1", "Melder Attrium", "", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(0, 10, Alarm.MelderType.Melder, "06/4", "Melder WC", "", Alarm.AlarmType.Alarm));
            internAlarmList.Add(new Alarm(0, 10, Alarm.MelderType.Melder, "06/5", "Melder Küche", "", Alarm.AlarmType.Alarm));
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
