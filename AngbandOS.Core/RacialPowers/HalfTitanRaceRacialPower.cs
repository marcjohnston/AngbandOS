namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HalfTitanRaceRacialPower : RacialPower
{
    private HalfTitanRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HalfTitanRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HalfTitanRace);
}