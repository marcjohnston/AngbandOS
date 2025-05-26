namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DwarfRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DwarfRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private DwarfRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}