namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class KlackonRaceRacialPower : RacialPower
{
    private KlackonRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(KlackonRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(KlackonRace);
}