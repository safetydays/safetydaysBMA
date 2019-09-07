using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Steuerung des Speichern und Laden von Szenarien
/// </summary>
public class SaveLoadController : MonoBehaviour
{
    public inputScreen InputScreen;
    public SaveView SaveView;

    // Start is called before the first frame update
    void Start()
    {
        SaveView.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Funktion für Speicher-Button-Click;
    /// Aufruf des Speicher-Dialogs
    /// </summary>
    public void onSaveButtonClicked()
    {
        activateSaveView();
    }

    /// <summary>
    /// Speicher-Dialog anzeigen
    /// </summary>
    public void activateSaveView()
    {
        SaveView.gameObject.SetActive(true);
    }

    /// <summary>
    /// Szenario als Json abspeichern
    /// </summary>
    /// <param name="filepath">Dateipfad mit Dateiname</param>
    public void SaveFile(string filename)
    {
        string filePath = Application.dataPath + "/" + filename + ".json";
        string json = InputScreen.toJSON();
        File.WriteAllText(filePath, json);
        Debug.Log("Szenario gespeichert!");
    }
}
