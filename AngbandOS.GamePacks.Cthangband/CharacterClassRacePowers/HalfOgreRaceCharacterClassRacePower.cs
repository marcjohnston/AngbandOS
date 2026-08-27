namespace AngbandOS.GamePacks.Cthangband;

public class HalfOgreRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOgreRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
}