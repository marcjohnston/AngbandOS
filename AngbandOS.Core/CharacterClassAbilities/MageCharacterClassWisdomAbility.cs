namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MageCharacterClassWisdomAbility : CharacterClassAbility
{
    private MageCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(MageCharacterClass);
    public override int Bonus => 0;
}