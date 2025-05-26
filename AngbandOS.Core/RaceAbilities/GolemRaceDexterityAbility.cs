namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GolemRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GolemRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private GolemRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}