namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ImpRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private ImpRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}