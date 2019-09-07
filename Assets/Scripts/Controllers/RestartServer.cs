using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartServer : MonoBehaviour
{
    public ExistingDbScript ExistingDbScript;

    // Start is called before the first frame update
    void Start()
    {
        ExistingDbScript.clearDb();
        GameObject.FindGameObjectWithTag("NetworkController").GetComponent<BMANetworkController>().restartHost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
