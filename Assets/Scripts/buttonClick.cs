using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;
public class buttonClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openScreen()
    {
        
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            //Main Menu
            case "Simulate_Btn":
                EditorUtility.DisplayDialog("Button Name", "Simulation", "OKAY");
                SceneManager.LoadScene("Simulation_Scrn");
                break;
            case "Learn_Btn":
                EditorUtility.DisplayDialog("Button Name", "Lernen", "OKAY");
                break;
            case "Evaluate_Btn":
                EditorUtility.DisplayDialog("Button Name", "Evaluation", "OKAY");
                break;
            case "Input_Btn":
                EditorUtility.DisplayDialog("Button Name", "Eingabe", "OKAY");
                break;
            case "Instruction_Btn":
                EditorUtility.DisplayDialog("Button Name", "Handbuch", "OKAY");
                break;
            //Simulation Menu
            case "Team_Btn":
                EditorUtility.DisplayDialog("Button Name", "Team", "OKAY");
                break;
            case "Single_Btn":
                EditorUtility.DisplayDialog("Button Name", "Single", "OKAY");
                break;
            case "Partner_Btn":
                EditorUtility.DisplayDialog("Button Name", "Partner", "OKAY");
                break;
            default:
                break;
        }
    }
}
