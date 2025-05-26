namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DarkElfRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DarkElfRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private DarkElfRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}