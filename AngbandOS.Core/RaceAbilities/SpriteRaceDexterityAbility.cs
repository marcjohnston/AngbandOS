namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpriteRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private SpriteRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}