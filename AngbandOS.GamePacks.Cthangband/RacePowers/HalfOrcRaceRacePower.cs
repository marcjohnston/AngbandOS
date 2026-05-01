namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOrcRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOrcRace);
}