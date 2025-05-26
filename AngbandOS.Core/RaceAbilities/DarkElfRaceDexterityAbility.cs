namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DarkElfRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DarkElfRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private DarkElfRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}