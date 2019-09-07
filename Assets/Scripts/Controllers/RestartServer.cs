using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartServer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("NetworkController").GetComponent<BMANetworkController>().restartHost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
