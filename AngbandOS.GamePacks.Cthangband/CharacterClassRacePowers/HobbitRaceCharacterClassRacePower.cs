namespace AngbandOS.GamePacks.Cthangband;

public class HobbitRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HobbitRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HobbitRace);
}