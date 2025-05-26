namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class VampireRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private VampireRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}