namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class FanaticCharacterClassWisdomAbility : CharacterClassAbility
{
    private FanaticCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(FanaticCharacterClass);
    public override int Bonus => 0;
}