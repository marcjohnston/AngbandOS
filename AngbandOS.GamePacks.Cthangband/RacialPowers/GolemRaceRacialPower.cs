namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GolemRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(GolemRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.GolemRace);
}