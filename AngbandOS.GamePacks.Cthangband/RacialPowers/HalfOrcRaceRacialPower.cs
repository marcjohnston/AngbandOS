namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOrcRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOrcRace);
}