using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColourButton()
    {
        this.gameObject.SetActive(false);
        //this.GetComponent<Button>().colors.normalColor = Color.red;
    }
}
