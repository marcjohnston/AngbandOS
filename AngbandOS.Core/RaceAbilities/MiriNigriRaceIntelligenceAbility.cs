namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MiriNigriRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private MiriNigriRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}