namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class SpectreRaceRacialPower : RacialPower
{
    private SpectreRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(SpectreRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(SpectreRace);
}