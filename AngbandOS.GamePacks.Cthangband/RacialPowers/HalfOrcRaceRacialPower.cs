namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOrcRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOrcRace);
}