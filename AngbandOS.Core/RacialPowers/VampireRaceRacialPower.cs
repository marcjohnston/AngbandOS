namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class VampireRaceRacialPower : RacialPower
{
    private VampireRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(VampireRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(VampireRace);
}