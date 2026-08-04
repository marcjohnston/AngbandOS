namespace AngbandOS.GamePacks.Cthangband;

public class GolemRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(GolemRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.GolemRace);
}