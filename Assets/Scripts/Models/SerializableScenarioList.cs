using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializableScenarioList
{
    [SerializeField]
    public List<SerializableScenario> scenarios = new List<SerializableScenario>();

    [SerializeField]
    public List<Alarm> alarms = new List<Alarm>();
}
