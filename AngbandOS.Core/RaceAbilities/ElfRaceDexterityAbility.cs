namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ElfRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ElfRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private ElfRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}