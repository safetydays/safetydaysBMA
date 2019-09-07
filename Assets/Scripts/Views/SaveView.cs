using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveView : MonoBehaviour
{
    public SaveLoadController SaveLoadController;
    public InputField InputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSaveButtonClicked()
    {
        if (InputField.text.Length > 0)
        {
            SaveLoadController.SaveFile(InputField.text);
            this.gameObject.SetActive(false);
        }
    }

    public void onAbortButtonClicked()
    {
        this.gameObject.SetActive(false);
    }
}
