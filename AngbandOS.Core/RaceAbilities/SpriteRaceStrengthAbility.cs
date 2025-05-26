namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpriteRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private SpriteRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}