namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class CyclopsRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(CyclopsRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private CyclopsRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}