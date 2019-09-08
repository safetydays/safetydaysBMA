using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioScroll_Controller : MonoBehaviour
{
    public Transform listParent = null;
    public Transform entryPrefab = null;

    private Stack<Transform> entries = new Stack<Transform>();

    public void Awake()
    {
        if (listParent == null)
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
        string[] dirs = Directory.GetFiles(Application.persistentDataPath, "*.json");

        foreach (string path in dirs) {
            this.AddNewEntry(Path.GetFileNameWithoutExtension(path));
        }
        
        if (dirs.Length == 0)
        {
            this.AddNewEntry("Neu anlegen");
        }
    }

    public void AddNewEntry( string scenarioName)
    {
        Transform newEntry = (Transform)Instantiate(entryPrefab);
        newEntry.gameObject.GetComponentInChildren<Text>().text = scenarioName;


        newEntry.gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
            { ListEntryClicked(scenarioName); });
        
        newEntry.SetParent(listParent);
        entries.Push(newEntry);
    }

    public void ListEntryClicked( string buttonName)
    {
        if (buttonName == "Neu anlegen")
        {
            SceneManager.LoadScene("ScenarioInput_Scrn");
        }
        else
        {
            //globale Variable füllen
            string local = Application.persistentDataPath + "/" + buttonName + ".json";
            GlobalSettings.Instance.filePathJSON = Application.persistentDataPath + "/" + buttonName + ".json";
            if (GlobalSettings.Instance.clientType != GlobalSettings.ClientType.SinglePlayer)
                SceneManager.LoadScene("ScenarioInput_Scrn");
            else
                SceneManager.LoadScene("SampleScene");
        }
    }

}
