﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// NetzwerkController zum Verbinden des Clients mit dem Server
/// </summary>
public class BMANetworkController : MonoBehaviour
{
    private NetworkManager networkManager;

    /// <summary>
    /// Standardmäßig den Server aktivieren, solange bis eine Verbindung zu einem Server aufgebaut werden soll
    /// </summary>
    void Start()
    {
        networkManager = this.GetComponent<NetworkManager>();
        networkManager.StartHost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Testet die Verbindung mit einer IP-Adresse
    /// </summary>
    /// <param name="ipAdress">IP-Adresse als String</param>
    /// <returns>Erfolgsmeldung der Verbindung</returns>
    public bool checkIPAdress(string ipAdress)
    {
        // Test the DNS resolution because Unity throws an error otherwise
        // https://msdn.microsoft.com/en-us/library/ms143998(v=vs.90)
        try
        {
            Dns.GetHostEntry(ipAdress);
        }
        catch (SocketException e)
        {
            //errorText.text = e.Message;
            return false;
        }
        return true;
    }


    public void connectWithHost(string ip)
    {
        if (ip == "" || !this.checkIPAdress(ip))
        {
            Debug.Log("IP-Adresse ist falsch");
            return;
        }
        networkManager.StopHost();

        networkManager.networkAddress = ip;
        networkManager.StartClient();
    }
}
