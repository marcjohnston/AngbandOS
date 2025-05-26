namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GnomeRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GnomeRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private GnomeRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}