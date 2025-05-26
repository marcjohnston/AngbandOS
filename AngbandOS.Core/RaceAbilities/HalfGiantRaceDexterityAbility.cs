namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfGiantRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfGiantRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfGiantRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}