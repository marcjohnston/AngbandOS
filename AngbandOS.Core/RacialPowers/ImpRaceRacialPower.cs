namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class ImpRaceRacialPower : RacialPower
{
    private ImpRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(ImpRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(ImpRace);
}