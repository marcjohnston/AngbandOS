namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorMageCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private WarriorMageCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(WarriorMageCharacterClass);
    public override int Bonus => 2;
}