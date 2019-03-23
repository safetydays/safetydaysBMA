using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
                //EditorUtility.DisplayDialog("Button Name", "Simulation", "OKAY");
                SceneManager.LoadScene("Simulation_Scrn");
                break;
            case "Learn_Btn":
                //EditorUtility.DisplayDialog("Button Name", "Lernen", "OKAY");
                break;
            case "Evaluate_Btn":
                //EditorUtility.DisplayDialog("Button Name", "Evaluation", "OKAY");
                break;
            case "Input_Btn":
                //EditorUtility.DisplayDialog("Button Name", "Eingabe", "OKAY");
                break;
            case "Instruction_Btn":
                //EditorUtility.DisplayDialog("Button Name", "Handbuch", "OKAY");
                break;
            //Simulation Menu
            case "Team_Btn":
                //EditorUtility.DisplayDialog("Button Name", "Team", "OKAY");
                SceneManager.LoadScene("Teacher_Student_Scrn");
                break;
            case "Single_Btn":
                //EditorUtility.DisplayDialog("Button Name", "Single", "OKAY");
                break;
            case "Partner_Btn":
                //EditorUtility.DisplayDialog("Button Name", "Partner", "OKAY");
                break;
            case "Trainer_Btn":
                //Trainer-Rolle speichern

                //nächsten Screen aufrufen
                SceneManager.LoadScene("IP_Adress_Scrn");
                break;
            case "Student_Btn":
                //Schüler-Rolle speichern

                //nächsten Screen aufrufen
                SceneManager.LoadScene("IP_Adress_Scrn");
                break;
            case "SaveIP_Btn":
                //wenn Trainer
                SceneManager.LoadScene("ScenarioInput_Scrn");
                //wenn Schüler
                SceneManager.LoadScene("SampleScene");  
                break;
            case "Home_Btn":
                SceneManager.LoadScene("MainMenu_Scrn");
                break;
            default:
                break;
        }
    }
}
