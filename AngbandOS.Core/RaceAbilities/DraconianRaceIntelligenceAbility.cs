namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DraconianRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DraconianRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private DraconianRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}