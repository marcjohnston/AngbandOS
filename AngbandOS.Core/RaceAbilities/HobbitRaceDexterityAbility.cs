namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HobbitRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HobbitRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}