namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class SkeletonRaceRacialPower : RacialPower
{
    private SkeletonRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(SkeletonRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(SkeletonRace);
}