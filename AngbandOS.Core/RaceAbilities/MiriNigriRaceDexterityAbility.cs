namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MiriNigriRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private MiriNigriRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}