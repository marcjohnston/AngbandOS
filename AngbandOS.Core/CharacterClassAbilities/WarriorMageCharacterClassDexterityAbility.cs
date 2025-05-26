namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorMageCharacterClassDexterityAbility : CharacterClassAbility
{
    private WarriorMageCharacterClassDexterityAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(DexterityAbility);
    public override string CharacterClassBindingKey => nameof(WarriorMageCharacterClass);
    public override int Bonus => 1;
}