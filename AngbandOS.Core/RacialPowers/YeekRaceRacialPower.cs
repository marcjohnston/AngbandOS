namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class YeekRaceRacialPower : RacialPower
{
    private YeekRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(YeekRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(YeekRace);
}