namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class YeekRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private YeekRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}