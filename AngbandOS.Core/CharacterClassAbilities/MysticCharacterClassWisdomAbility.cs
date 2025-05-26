namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MysticCharacterClassWisdomAbility : CharacterClassAbility
{
    private MysticCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(MysticCharacterClass);
    public override int Bonus => 2;
}