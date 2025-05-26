namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MindcrafterCharacterClassStrengthAbility : CharacterClassAbility
{
    private MindcrafterCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(MindcrafterCharacterClass);
    public override int Bonus => -1;
}