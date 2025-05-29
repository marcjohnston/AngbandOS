namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HalfOgreRaceRacialPower : RacialPower
{
    private HalfOgreRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HalfOgreRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HalfOgreRace);
}