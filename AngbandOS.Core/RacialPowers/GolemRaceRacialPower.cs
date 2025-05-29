namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class GolemRaceRacialPower : RacialPower
{
    private GolemRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(GolemRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(GolemRace);
}