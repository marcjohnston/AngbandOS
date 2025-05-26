namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTrollRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfTrollRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}