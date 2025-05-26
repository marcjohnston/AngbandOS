namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HighElfRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HighElfRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}