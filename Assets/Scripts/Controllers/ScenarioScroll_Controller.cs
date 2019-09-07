using System.Collections;
using System.Collections.Generic;
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
        //Pfad auslesen um Datenbankeinträge zu bekommen
    }

    public void AddNewEntry()
    {
        Transform newEntry = (Transform)Instantiate(entryPrefab);
        newEntry.gameObject.GetComponentInChildren<Text>().text = "Button vom Programm";
        newEntry.SetParent(listParent);
        entries.Push(newEntry);
    }

    public void ListEntryClicked( Text buttonName)
    {

    }

}
