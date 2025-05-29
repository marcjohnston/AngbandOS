namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class HobbitRaceRacialPower : RacialPower
{
    private HobbitRaceRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(HobbitRaceRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(HobbitRace);
}