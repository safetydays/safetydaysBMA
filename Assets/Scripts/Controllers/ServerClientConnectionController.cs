using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static Alarm;

/// <summary>
/// Nachrichten senden zwischen Client und Server
/// </summary>
public class ServerClientConnectionController : NetworkBehaviour
{
    public AlarmList alarmList;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isServer)
        {
            
        }
    }

    /// <summary>
    /// Wird nur auf dem Client ausgeführt
    /// </summary>
    /// <param name="string1"></param>
    /// <param name="string2"></param>
    /// <param name="string3"></param>
    [ClientRpc]
    public void RpcSendStringsToServer(Alarm alarm)
    {
        Debug.Log("Meldung: " + alarm.meldung1);
        alarmList.addAlarm(alarm);
    }

    public void Test()
    {
        Alarm alarm = new Alarm(0, 0, Alarm.MelderType.Melder, "Meldung 1", "Meldung 2", AlarmType.Alarm);
        //RpcSendStringsToServer(alarm);
        alarmList.addAlarm(alarm);
    }
}
