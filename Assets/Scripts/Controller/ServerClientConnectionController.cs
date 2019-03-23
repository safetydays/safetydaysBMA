using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Nachrichten senden zwischen Client und Server
/// </summary>
public class ServerClientConnectionController : NetworkBehaviour
{
    public enum AlarmType { Alarm, Fault, Off};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isServer)
        {
            RpcSendStringsToServer("0", "0:00", "Melder 1", "Meldung 1", "Meldung 2", AlarmType.Alarm);
        }
    }

    /// <summary>
    /// Wird nur auf dem Client ausgeführt
    /// </summary>
    /// <param name="string1"></param>
    /// <param name="string2"></param>
    /// <param name="string3"></param>
    [ClientRpc]
    public void RpcSendStringsToServer(string id, string time, string melderTyp, string meldung1, string meldung2, AlarmType alarmType)
    {
        Debug.Log("Test: " + string1);
    }
}
