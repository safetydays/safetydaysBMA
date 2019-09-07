using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableScenario
{
    public int Id;
    public string MelderType;
    public string AlarmType;
    public string TimeDelay;
    public string MelderGruppe;

    public SerializableScenario(Scenario scenario)
    {
        this.Id = scenario.Id;
        this.MelderType = scenario.MelderType;
        this.AlarmType = scenario.AlarmType;
        this.TimeDelay = scenario.TimeDelay;
        this.MelderGruppe = scenario.MelderGruppe;
    }

    public SerializableScenario(int id, string melderType, string alarmType, string timeDelay, string melderGruppe)
    {
        this.Id = id;
        this.MelderType = melderType;
        this.AlarmType = alarmType;
        this.TimeDelay = timeDelay;
        this.MelderGruppe = melderGruppe;
    }

}
