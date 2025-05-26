namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTitanRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfTitanRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}