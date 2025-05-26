namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOrcRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfOrcRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}