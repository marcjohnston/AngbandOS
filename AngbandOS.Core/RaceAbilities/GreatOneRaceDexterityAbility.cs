namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GreatOneRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GreatOneRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private GreatOneRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}