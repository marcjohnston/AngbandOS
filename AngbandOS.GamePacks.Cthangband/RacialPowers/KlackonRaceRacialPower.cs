namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KlackonRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(KlackonRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.KlackonRace);
}