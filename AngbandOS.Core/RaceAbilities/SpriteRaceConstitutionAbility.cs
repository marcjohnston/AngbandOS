namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpriteRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private SpriteRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}