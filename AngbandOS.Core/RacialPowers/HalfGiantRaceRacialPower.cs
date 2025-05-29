namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HalfGiantRaceRacialPower : RacialPower
{
    private HalfGiantRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HalfGiantRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HalfGiantRace);
}