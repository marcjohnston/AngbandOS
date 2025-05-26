namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOgreRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfOgreRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}