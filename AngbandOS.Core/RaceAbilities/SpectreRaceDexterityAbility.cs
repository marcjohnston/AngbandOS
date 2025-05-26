namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpectreRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private SpectreRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}