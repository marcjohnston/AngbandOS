namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HobbitRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HobbitRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HobbitRace);
}