namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class YeekRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private YeekRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}