namespace AngbandOS.GamePacks.Cthangband;

public class KlackonRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(KlackonRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.KlackonRace);
}