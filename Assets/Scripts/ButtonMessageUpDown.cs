using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMessageUpDown : MonoBehaviour
{
    public FATController fatController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void displayNextMessageInHistory()
    {
        fatController.displayNextMessageInHistory();
    }

    public void displayPreviousMessageInHistory()
    {
        fatController.displayPreviousMessageInHistory();
    }
}
