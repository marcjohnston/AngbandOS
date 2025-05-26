namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KoboldRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private KoboldRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}