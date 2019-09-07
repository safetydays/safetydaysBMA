using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioScroll_Controller : MonoBehaviour
{
    public Transform listParent = null;
    public Transform entryPrefab = null;

    private Stack<Transform> entries = new Stack<Transform>();

    public void Awake()
    {
        if (listParent  == null)
        {
            Debug.LogWarning("ListParent muss assigned sein", this);
        }
        if (entryPrefab == null)
        {
            Debug.LogWarning("Prefab muss assigned sein", this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Szenario 
        

        //Pfad auslesen um Datenbankeinträge zu bekommen
        string[] dirs = Directory.GetFiles(Application.dataPath, "*.json");

        /*foreach (string path in dirs) { }
        myObject = JsonUtility.FromJson<MyClass>(path); }

        myObject = JsonUtility.FromJson<MyClass>(json);*/
        //Button hinzufügen
        AddNewEntry("Szenario1");
        AddNewEntry("Szenario2");
        AddNewEntry("Szenario3");
        AddNewEntry("Szenario4");
    }

    public void AddNewEntry( string scenarioName)
    {

        Transform newEntry = (Transform)Instantiate(entryPrefab);
        newEntry.gameObject.GetComponentInChildren<Text>().text = scenarioName;

        string buttonName = "Szenario1";

        newEntry.gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
           {ListEntryClicked(scenarioName);});
        newEntry.SetParent(listParent);
        entries.Push(newEntry);
    }

    public void ListEntryClicked( string buttonName)
    {
        
    }

}
