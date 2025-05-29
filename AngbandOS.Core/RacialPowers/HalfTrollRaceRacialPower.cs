namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HalfTrollRaceRacialPower : RacialPower
{
    private HalfTrollRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HalfTrollRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HalfTrollRace);
}