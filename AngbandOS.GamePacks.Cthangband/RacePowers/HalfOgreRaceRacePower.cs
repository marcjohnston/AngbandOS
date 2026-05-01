namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOgreRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOgreRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
}