using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BMA_Back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backClicked()
    {
        if (GlobalSettings.Instance.clientType == GlobalSettings.ClientType.Student)
            SceneManager.LoadScene("ScenarioSelection_Scrn");
        else
            SceneManager.LoadScene("Teacher_Student_Scrn");
    }
}
