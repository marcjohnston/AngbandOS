namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HumanRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HumanRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}