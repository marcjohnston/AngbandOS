namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MageCharacterClassCharismaAbility : CharacterClassAbility
{
    private MageCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(MageCharacterClass);
    public override int Bonus => 1;
}