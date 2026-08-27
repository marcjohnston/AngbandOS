namespace AngbandOS.GamePacks.Cthangband;

public class KlackonRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(KlackonRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.KlackonRace);
}