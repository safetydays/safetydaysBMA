using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static GlobalSettings Instance;

    public enum ClientType { Teacher, Student, SinglePlayer};
    public ClientType clientType { get; set; }

    void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance.gameObject);
            Debug.Log("Alarm-List-Objekt schon vorhanden!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            this.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
