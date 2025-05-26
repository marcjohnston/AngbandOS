namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DraconianRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DraconianRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private DraconianRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}