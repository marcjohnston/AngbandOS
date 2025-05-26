namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GnomeRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GnomeRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private GnomeRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}