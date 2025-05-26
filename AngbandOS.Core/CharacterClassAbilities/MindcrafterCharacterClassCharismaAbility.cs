namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MindcrafterCharacterClassCharismaAbility : CharacterClassAbility
{
    private MindcrafterCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(MindcrafterCharacterClass);
    public override int Bonus => 2;
}