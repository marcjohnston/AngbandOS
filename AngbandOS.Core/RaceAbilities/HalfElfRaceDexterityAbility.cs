namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfElfRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfElfRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfElfRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}