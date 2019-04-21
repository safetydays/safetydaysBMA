using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistingDbScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ds = new DataService("scenarios.db");
        //ds.CreateDB ();
        var people = ds.getScenario();
        ToConsole(people);





    }
    private void ToConsole(IEnumerable<Scenario> people)
    {
        foreach (var person in people)
        {
            ToConsole(person.ToString());
        }
    }

    private void ToConsole(string msg)
    {
        Debug.Log(msg);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
