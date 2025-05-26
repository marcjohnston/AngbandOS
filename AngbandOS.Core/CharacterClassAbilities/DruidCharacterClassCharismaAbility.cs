namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class DruidCharacterClassCharismaAbility : CharacterClassAbility
{
    private DruidCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(DruidCharacterClass);
    public override int Bonus => 3;
}