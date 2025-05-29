namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HalfOrcRaceRacialPower : RacialPower
{
    private HalfOrcRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HalfOrcRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HalfOrcRace);
}