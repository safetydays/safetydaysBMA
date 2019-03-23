using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zentrale Statemachine zur Steuerung
/// </summary>
public class Statemachine : MonoBehaviour
{
    public enum State {Start};

    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Start;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setState(State state)
    {
        this.currentState = state;
    }
}
