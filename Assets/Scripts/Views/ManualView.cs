using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualView : MonoBehaviour
{
    public ManualList ManualList;
    public Text Title;
    public Text Content;
    public Button PreviousButton;
    public Button NextButton;

    private int currentElement;

    // Start is called before the first frame update
    void Start()
    {
        if (ManualList.getTexts().Length == 0 || ManualList.getTitles().Length == 0)
            Debug.LogError("Text-Listen sind leer!");
        else if (ManualList.getTexts().Length != ManualList.getTitles().Length)
            Debug.LogError("Text-Listen haben eine unterschiedliche Anzahl an Elementen!");

        Title.text = ManualList.getTitles()[0];
        Content.text = ManualList.getTexts()[0];
        currentElement = 0;
        PreviousButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNextButtonClicked()
    {
        PreviousButton.interactable = true;
        if (currentElement < ManualList.getTitles().Length - 1)
            currentElement++;
        else
            NextButton.interactable = false;
        Title.text = ManualList.getTitles()[currentElement];
        Content.text = ManualList.getTexts()[currentElement];
    }

    public void OnPreviousButtonClicked()
    {
        NextButton.interactable = true;
        if (currentElement > 0)
            currentElement--;
        else
            PreviousButton.interactable = false;
        Title.text = ManualList.getTitles()[currentElement];
        Content.text = ManualList.getTexts()[currentElement];
    }
}
