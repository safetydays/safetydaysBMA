﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Struct für die Melder-Nachricht, die vom Server (Lehrer) gesendet wurde
/// </summary>
public struct Alarm
{
    // FalseAlarm: Fehlalarm, Alarm: Echter Alarm
    public enum AlarmType { FalseAlarm, Alarm, Fault, Off };
    public enum MelderType { Melder, Löschanlage};

    public int id;
    public int time;
    public MelderType melderTyp;
    public string meldung1;
    public string meldung2;
    public AlarmType alarmType;

    public Alarm(int pId, int pTime, MelderType pMelderTyp, string pMeldung1, string pMeldung2, AlarmType pAlarmType)
    {
        id = pId;
        time = pTime;
        melderTyp = pMelderTyp;
        meldung1 = pMeldung1;
        meldung2 = pMeldung2;
        alarmType = pAlarmType;
    }
}

/// <summary>
/// Speichern der Melder-Nachrichten
/// </summary>
public class AlarmList : MonoBehaviour
{
    public List<Alarm> internAlarmList;

    // Start is called before the first frame update
    void Start()
    {
        internAlarmList = new List<Alarm>();
        internAlarmList.Add(new Alarm(0, 0, Alarm.MelderType.Melder, "06/3", "Melder Flur O", Alarm.AlarmType.Alarm));
        internAlarmList.Add(new Alarm(0, 0, Alarm.MelderType.Melder, "06/2", "Melder Flur W", Alarm.AlarmType.Alarm));
        internAlarmList.Add(new Alarm(0, 10, Alarm.MelderType.Melder, "06/1", "Melder Attrium", Alarm.AlarmType.Alarm));
        internAlarmList.Add(new Alarm(0, 10, Alarm.MelderType.Melder, "06/4", "Melder WC", Alarm.AlarmType.Alarm));
        internAlarmList.Add(new Alarm(0, 10, Alarm.MelderType.Melder, "06/5", "Melder Küche", Alarm.AlarmType.Alarm));
    }

    // Update is called once per frame
    void Update()
    {
        
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
}