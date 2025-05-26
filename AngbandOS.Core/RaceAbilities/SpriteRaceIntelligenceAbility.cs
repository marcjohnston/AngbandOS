namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpriteRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private SpriteRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}