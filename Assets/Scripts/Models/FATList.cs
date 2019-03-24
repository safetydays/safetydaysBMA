using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FATList : MonoBehaviour
{
    public List<Alarm> internAlarmList;

    // Start is called before the first frame update
    void Start()
    {
        internAlarmList = new List<Alarm>();
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

    public void removeAllFalseAlarmsFromList()
    {
        this.internAlarmList.RemoveAll(x => x.alarmTyp == Alarm.AlarmType.FalseAlarm);
    }
}
