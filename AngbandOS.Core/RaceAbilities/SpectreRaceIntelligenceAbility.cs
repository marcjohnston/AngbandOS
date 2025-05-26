namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpectreRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private SpectreRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}