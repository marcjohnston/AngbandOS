namespace AngbandOS.GamePacks.Cthangband;

public class HalfTrollRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfTrollRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
}