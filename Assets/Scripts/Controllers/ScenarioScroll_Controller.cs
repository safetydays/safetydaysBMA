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
        string[] dirs = Directory.GetFiles(Application.dataPath, "*.json");

        foreach (string path in dirs) {
            this.AddNewEntry(Path.GetFileNameWithoutExtension(path));
        }
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
        //globale Variable füllen
        string local = Application.dataPath +"/"+ buttonName + ".json";
        GlobalSettings.Instance.filePathJSON = Application.dataPath + "/" + buttonName + ".json";
        if(GlobalSettings.Instance.clientType != GlobalSettings.ClientType.SinglePlayer)
            SceneManager.LoadScene("ScenarioInput_Scrn");
        else
            SceneManager.LoadScene("SampleScene");
    }

}
