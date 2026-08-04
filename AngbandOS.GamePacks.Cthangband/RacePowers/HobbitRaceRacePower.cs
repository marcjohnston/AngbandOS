namespace AngbandOS.GamePacks.Cthangband;

public class HobbitRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HobbitRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HobbitRace);
}