namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOgreRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOgreRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
}