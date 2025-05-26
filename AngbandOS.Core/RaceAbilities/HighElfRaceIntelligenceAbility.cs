namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HighElfRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HighElfRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}