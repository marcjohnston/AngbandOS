namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KlackonRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private KlackonRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}