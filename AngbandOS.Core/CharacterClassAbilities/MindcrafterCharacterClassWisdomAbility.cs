namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MindcrafterCharacterClassWisdomAbility : CharacterClassAbility
{
    private MindcrafterCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(MindcrafterCharacterClass);
    public override int Bonus => 3;
}