namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfElfRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfElfRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfElfRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}