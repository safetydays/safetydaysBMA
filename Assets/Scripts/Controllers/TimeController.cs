using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Schreibt die Meldungen von der AlarmListe in die FATListe
/// </summary>
public class TimeController : MonoBehaviour
{
    public AlarmList alarmList;
    public FATList fatList;
    public FATController fatController;

    private float startTime;
    private int lastIDUpdatet;
    private float timeSinceLastUpdate;

    /// <summary>
    /// Timer initialisieren
    /// </summary>
    void Start()
    {
        startTime = Time.time;
        lastIDUpdatet = 0;
        timeSinceLastUpdate = 0;
    }

    /// <summary>
    /// Das nächste Element in der AlarmListe auf Ablauf der Zeit überprüfen
    /// </summary>
    void Update()
    {
        if (alarmList.getAlarmCount() > lastIDUpdatet)
        {
            Alarm nextAlarm = alarmList.getAlarm(lastIDUpdatet);
            if (nextAlarm.deltatime < Time.time - timeSinceLastUpdate)
            {
                lastIDUpdatet++;
                timeSinceLastUpdate = Time.time;
                fatList.addAlarm(nextAlarm);
                Debug.Log("Element ins FAT übernommen - " + nextAlarm.id);
                fatController.updateDisplay();
            }
        }
    }
}
