using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;

public class buttonClick : MonoBehaviour
{
    private BMANetworkController bmaNetworkController;
    public InputField ownIPField;
    public InputField ipField;

    // Start is called before the first frame update
    void Start()
    {
        if (ownIPField != null)
            ownIPField.text = BMANetworkController.LocalIPAddress();
        if (ipField != null)
        {
            ipField.text = GameObject.FindGameObjectWithTag("NetworkController").GetComponent<NetworkManager>().networkAddress;
        }
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
            case "Manual_Btn":
                SceneManager.LoadScene("Manual_Scrn");
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
                GlobalSettings.Instance.clientType = GlobalSettings.ClientType.SinglePlayer;
                SceneManager.LoadScene("ScenarioSelection_Scrn"); 
                break;
            case "Partner_Btn":
                //EditorUtility.DisplayDialog("Button Name", "Partner", "OKAY");
                break;
            case "Trainer_Btn":
                //Trainer-Rolle speichern

                //nächsten Screen aufrufen
                GlobalSettings.Instance.clientType = GlobalSettings.ClientType.Teacher;
                SceneManager.LoadScene("Load_Create_Scrn");
                break;
            case "NewScenario_Btn":
                SceneManager.LoadScene("ScenarioInput_Scrn");
                break;
            case "LoadScenario_Btn":
                SceneManager.LoadScene("ScenarioSelection_Scrn");
                break;
            case "Student_Btn":
                //Schüler-Rolle speichern

                //nächsten Screen aufrufen
                GlobalSettings.Instance.clientType = GlobalSettings.ClientType.Student;
                SceneManager.LoadScene("IP_Adress_Scrn");
                break;
            case "SaveIP_Btn":
                //wenn Trainer
                //SceneManager.LoadScene("ScenarioInput_Scrn");
                //wenn Schüler
                bmaNetworkController = GameObject.FindGameObjectWithTag("NetworkController").GetComponent<BMANetworkController>();
                bmaNetworkController.connectWithIPField(ownIPField, ipField);
                SceneManager.LoadScene("SampleScene");  
                break;
            case "Home_Btn":
                switch (SceneManager.GetActiveScene().name){
                    case "ScenarioInput_Scrn":
                        SceneManager.LoadScene("Teacher_Student_Scrn");
                        break;
                    case "IP_Adress_Scrn":
                        SceneManager.LoadScene("Teacher_Student_Scrn");
                        break;
                    case "Teacher_Student_Scrn":
                        SceneManager.LoadScene("Simulation_Scrn");
                        break;
                    case "Simulation_Scrn":
                        SceneManager.LoadScene("MainMenu_Scrn");
                        break;
                    default:
                        SceneManager.LoadScene("MainMenu_Scrn");
                        break;
                }
                break;
            default:
                break;
        }
    }
}
