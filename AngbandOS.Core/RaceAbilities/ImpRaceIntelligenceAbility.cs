namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ImpRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private ImpRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}