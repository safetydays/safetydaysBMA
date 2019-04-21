using SQLite4Unity3d;

public class Scenario
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string MelderType { get; set; }
    public string AlarmType { get; set; }
    public string TimeDelay { get; set; }
    public string MelderGruppe { get; set;}

    public override string ToString()
    {
        return string.Format("[Scneario: Id={0}, MelderType={1},  ALarmType={2}, TimeDely={3}, MelderGruppe={4}]", Id, MelderType, AlarmType, TimeDelay, MelderGruppe);
    }
}