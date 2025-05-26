namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfGiantRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfGiantRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfGiantRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}